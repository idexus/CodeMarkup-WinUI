//
// Apache 2.0 License
// Copyright Pawel Krzywdzinski
//

using System;
using Microsoft.CodeAnalysis;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace CodeMarkup.WinUI.Generator.SharpObjects
{
    public class ClassGenerator
    {
        GeneratorExecutionContext context;
        INamedTypeSymbol mainSymbol;

        StringBuilder builder;

        string symbolName = null;
        string contentPropertyName = null;
        string namespaceName = null;
        bool isSingleItemContainer = false;
        string containerOfTypeName = null;
        bool isNewPropertyContainer = false;
        bool isAlreadyContainerOfThis = false;
        bool isCustomized = false;

        public ClassGenerator(GeneratorExecutionContext context, INamedTypeSymbol symbol, bool isCustomized)
        {
            this.context = context;
            this.mainSymbol = symbol;
            this.isCustomized = isCustomized;

            this.symbolName = symbol.ToDisplayString().Split('.').Last();
            this.namespaceName = mainSymbol.ContainingNamespace.ToDisplayString().StartsWith(Shared.WinUIPrefix) ? Shared.ControlsLibPrefix : mainSymbol.ContainingNamespace.ToDisplayString();

            SetupContainerIfNeeded();
        }

        void SetupContainerIfNeeded()
        {
            this.contentPropertyName = GetContainerPropertyNameFor(mainSymbol);
            this.isNewPropertyContainer = IsNewContainerProperty();

            this.isAlreadyContainerOfThis = Helpers.IsGenericIList(mainSymbol, out var containerOfType);
            if (contentPropertyName != null && isAlreadyContainerOfThis) throw new ArgumentException($"Type {mainSymbol.ToDisplayString()} defines IList interface, you can not use ContentProperty attribute");

            if (isAlreadyContainerOfThis)
            {
                this.containerOfTypeName = containerOfType.ToDisplayString();
                this.contentPropertyName = "this";
                this.isSingleItemContainer = false;
            }
            else
            {
                if (!isNewPropertyContainer && mainSymbol.ContainingNamespace.ToDisplayString().Equals(Shared.ControlsLibPrefix))
                {
                    this.contentPropertyName = FindContainerPropertyName();
                }

                if (!string.IsNullOrEmpty(this.contentPropertyName))
                { 
                    IPropertySymbol contentPropertySymbol = FindPropertySymbolWithName(this.contentPropertyName);
                    if (contentPropertySymbol == null) throw new Exception($"No content property for: {mainSymbol.ToDisplayString()}");

                    var contentPropertyType = (INamedTypeSymbol)((contentPropertySymbol).Type);
                    if (Helpers.IsGenericIList(contentPropertyType, out var ofType))
                    {
                        this.containerOfTypeName = ofType.ToDisplayString();
                        this.isSingleItemContainer = false;
                    }
                    else
                    {
                        this.containerOfTypeName = contentPropertyType.ToDisplayString();
                        this.isSingleItemContainer = true;
                    }
                }
            }
        }

        bool IsNewContainerProperty()
        {
            if (mainSymbol.GetAttributes().FirstOrDefault(e => e.AttributeClass.Name.Equals(Shared.ContainerPropertyAttributeString)) == null)
                return false;

            bool isNewContainer = false;
            Helpers.LoopDownToObject(mainSymbol.BaseType, type =>
            {
                isNewContainer = type.GetAttributes().FirstOrDefault(e => e.AttributeClass.Name.Equals(Shared.ContainerPropertyAttributeString)) != null;
                return isNewContainer;
            });
            return isNewContainer;
        }

        string GetContainerPropertyNameFor(INamedTypeSymbol symbol)
        {
            var attributeData = symbol.GetAttributes().FirstOrDefault(e => e.AttributeClass.Name.Equals(Shared.ContainerPropertyAttributeString));
            return attributeData != null ? (string)attributeData.ConstructorArguments.FirstOrDefault().Value : null;
        }

        string FindContainerPropertyName()
        {
            string name = null;
            Helpers.LoopDownToObject(mainSymbol, type =>
            {
                name = GetContainerPropertyNameFor(type);
                return name != null;
            });
            return name;
        }

        IPropertySymbol FindPropertySymbolWithName(string propertyName)
        {
            IPropertySymbol propertySymbol = GetPropertyFromInterface(propertyName);
            if (propertySymbol == null)
            {
                Helpers.LoopDownToObject(mainSymbol, type =>
                {
                    propertySymbol = (IPropertySymbol)(type.GetMembers(propertyName).FirstOrDefault());
                    return propertySymbol != null;
                });
            }
            return propertySymbol;
        }

        public void Build()
        {
            builder = new StringBuilder();

            builder.AppendLine("//");
            builder.AppendLine("// <auto-generated>");
            builder.AppendLine("//");
            builder.AppendLine();

            builder.AppendLine("#nullable enable");
            if (!namespaceName.Equals(Shared.ControlsLibPrefix))
                builder.AppendLine("#pragma warning disable CS0108");
            builder.AppendLine();

            GenerateClassNamespace();

            builder.AppendLine();
            if (!namespaceName.Equals(Shared.ControlsLibPrefix))
                builder.AppendLine("#pragma warning restore CS0108");
            builder.AppendLine("#nullable restore");

            context.AddSource($"{mainSymbol.ContainingNamespace.ToDisplayString()}.{Helpers.GetNormalizedFileName(mainSymbol)}.g.cs", builder.ToString());
        }

        public string GetUsingString()
        {
            if (!namespaceName.Equals(Shared.ControlsLibPrefix))
                return  $@"using {Shared.ControlsLibPrefix};

    ";
            return "";
        }

        void GenerateClassNamespace()
        {
            this.GenerateContainerUsingsIfNeeded();
            builder.AppendLine($@"
using Microsoft.UI.Xaml.Data;

namespace {namespaceName}
{{
	{GetUsingString()}[Bindable]
    public partial class {symbolName}{BaseString()}
	{{");
            GenerateClassBody();
            builder.AppendLine($@"
    }}
}}");
        }

        // ------- container usings -------

        void GenerateContainerUsingsIfNeeded()
        {
            if (containerOfTypeName != null)
                builder.AppendLine($@"
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Generic;");
        }

        // ------- base string -------


        string BaseString()
        {
            var baseString = isCustomized ? "" : $"{mainSymbol.ToDisplayString()}";
            if (containerOfTypeName != null && !isAlreadyContainerOfThis)
            {
                if (baseString != "") baseString += ", ";
                baseString += $"IEnumerable";
            }
            if (containerOfTypeName != null || isAlreadyContainerOfThis)
            {
                if (containerOfTypeName.Equals(Shared.UIElementTypeName)) baseString += $", IUIElementContainer";
            }
            return baseString == "" ? "" : $" : {baseString}";
        }

        void GenerateClassBody()
        {
            GenerateConstructors();
            GenerateSingleItemContainer();
            GenerateCollectionContainer();
            GenerateDependencyProperties();
        }

        // ---------------------------------
        // ----- single item container -----
        // ---------------------------------

        void GenerateSingleItemContainer()
        {
            if (containerOfTypeName != null && isSingleItemContainer == true)
            {
                var newPrefix = isNewPropertyContainer ? " new" : "";

                builder.AppendLine($@"
        // ----- single item container -----

        IEnumerator IEnumerable.GetEnumerator() {{ yield return this.{contentPropertyName}; }}
        public{newPrefix} void Add({containerOfTypeName} {contentPropertyName.ToLower()}) => this.{contentPropertyName} = {contentPropertyName.ToLower()};");
            }
        }

        // --------------------------------
        // ----- collection container -----    
        // --------------------------------

        void GenerateCollectionContainer()
        {

            if (containerOfTypeName != null && isSingleItemContainer == false && !isAlreadyContainerOfThis)
            {
                var prefix = $"this.{contentPropertyName}";

                builder.AppendLine($@"
        // ----- collection container -----

        IEnumerator IEnumerable.GetEnumerator() => {prefix}.GetEnumerator();
        public void Add({containerOfTypeName} item) => {prefix}.Add(item);");

            }
        }

        // ------------------------
        // ----- constructors -----
        // ------------------------

        // no params constructor

        void GenerateNoParamConstructor()
        {
            builder.AppendLine($@"
        public {mainSymbol.Name}() {{ }}");
        }

        // additional constructors

        void GenerateConstructors()
        {
            var argsString = "";
            var baseArgsString = "";
            var thisTail = ": this()";
            var baseTail = ": base()";
            var objectTail = "";
            var camelCaseName = Helpers.CamelCase(mainSymbol.Name);

            var buildAdditionalConstructor = () =>
            {
                if (!isCustomized)
                    builder.AppendLine($@"
        public {mainSymbol.Name}({(argsString == "" ? "" : argsString.Substring(0,argsString.Length-2))}) {baseTail} {{ }}
        ");

                builder.AppendLine($@"
        public {mainSymbol.Name}({argsString}out {symbolName} {camelCaseName}{objectTail}) {thisTail}
        {{
            {camelCaseName}{objectTail} = this;
        }}");

                if (containerOfTypeName != null || isAlreadyContainerOfThis)
                    builder.AppendLine($@"
        public {mainSymbol.Name}({argsString}System.Func<{mainSymbol.Name}, {mainSymbol.Name}> configure) {thisTail}
        {{
            configure(this);
        }}

        public {mainSymbol.Name}({argsString}out {mainSymbol.Name} {camelCaseName}, System.Func<{mainSymbol.Name}, {mainSymbol.Name}> configure) {thisTail}
        {{
            {Helpers.CamelCase(mainSymbol.Name)} = this;
            configure(this);
        }}");
            };

            builder.AppendLine($@"
        // ----- constructors -----");

            var isExplicitlyDeclared = mainSymbol.Constructors.FirstOrDefault(e => e.DeclaredAccessibility == Accessibility.Public && e.Parameters.Count() == 0 && !e.IsImplicitlyDeclared) != null;
            var isImplicitlyDeclared = mainSymbol.Constructors.FirstOrDefault(e => e.DeclaredAccessibility == Accessibility.Public && e.Parameters.Count() == 0 && e.IsImplicitlyDeclared) != null;

            if (isCustomized)
            {
                var isNoParamInParent = mainSymbol.BaseType.Constructors.FirstOrDefault(e => e.DeclaredAccessibility == Accessibility.Public && e.Parameters.Count() == 0) != null;
            
                // this() constructor
                if (isImplicitlyDeclared || (isNoParamInParent && !isExplicitlyDeclared))
                {
                    GenerateNoParamConstructor();
                    thisTail = "";
                }
                if (isImplicitlyDeclared || isExplicitlyDeclared || (isNoParamInParent && !isExplicitlyDeclared))
                    buildAdditionalConstructor();
            }
            else
            {
                if (isImplicitlyDeclared || isExplicitlyDeclared)
                {
                    thisTail = "";
                    baseTail = "";
                    buildAdditionalConstructor();
                }
            }

            // this(...) constructors
            var constructors = mainSymbol.Constructors.Where(e => e.DeclaredAccessibility == Accessibility.Public && e.Parameters.Count() > 0 && !e.IsImplicitlyDeclared);
            foreach (var constructor in constructors)
            {
                argsString = "";
                baseArgsString = "";

                var argsList = new List<string>();
                foreach (var argument in constructor.Parameters)
                {
                    var camelCaseArgName = Helpers.CamelCase(argument.Name);
                    argsList.Add(camelCaseArgName);

                    argsString += $"{argument.Type.ToDisplayString()} {camelCaseArgName}, ";

                    if (!string.IsNullOrEmpty(baseArgsString))
                        baseArgsString += ", ";
                    baseArgsString += $"{camelCaseArgName}";
                }

                thisTail = $": this({baseArgsString})";
                baseTail = $": base({baseArgsString})";
                objectTail = argsList.Contains(camelCaseName, StringComparer.Ordinal) ? "Object" : "";
                buildAdditionalConstructor();
            }
        }

        // --------------------------------------
        // ---- generate dependency properties ----
        // --------------------------------------

        string GetPropertyCallback(ISymbol symbol)
        {
            var attributes = symbol.GetAttributes();
            var attributeData = attributes.FirstOrDefault(e => e.AttributeClass.Name.Equals(Shared.PropertyCallbackAttributeString, StringComparison.Ordinal));
            if (attributeData != null)
            {
                var arguments = attributeData.ConstructorArguments;
                if (arguments[0].Value != null) return (string)arguments[0].Value;
            }
            return null;
        }

        string GetDefaultValueString(ISymbol symbol, string typeName)
        {
            var attributes = symbol.GetAttributes();
            var attributeData = attributes.FirstOrDefault(e => e.AttributeClass.Name.Equals(Shared.DefaultValueAttributeString, StringComparison.Ordinal));
            if (attributeData != null)
            {

                var value = attributeData.ConstructorArguments[0].Value.ToString();
                if (typeName.Equals("string", StringComparison.Ordinal))
                    value = $"\"{value}\"";
                if (typeName.Equals("double", StringComparison.Ordinal) || typeName.Equals("float", StringComparison.Ordinal))
                    value = value.Replace(",", ".");
                return value;
            }
            return null;
        }

        IPropertySymbol GetPropertyFromInterface(string name)
        {
            if (Shared.IsDependencyObject(mainSymbol))
            {
                var dependencyInterfaces = mainSymbol
                    .Interfaces
                    .Where(e => e.GetAttributes().FirstOrDefault(e => e.AttributeClass.Name.Equals(Shared.DependencyPropertiesAttributeString, StringComparison.Ordinal)) != null);

                if (dependencyInterfaces.Count() > 0)

                    foreach (var inter in dependencyInterfaces)
                    {
                        var properties = inter
                            .GetMembers()
                            .Where(e => e.Kind == SymbolKind.Property);

                        foreach (var prop in properties)
                            if (prop.Name.Equals(name, StringComparison.Ordinal))
                                return (IPropertySymbol)prop;
                    }
            }
            return null;
        }

        void GenerateDependencyProperties()
        {
            if (Shared.IsDependencyObject(mainSymbol))
            {
                var dependencyInterfaces = mainSymbol
                    .Interfaces
                    .Where(e => e.GetAttributes().FirstOrDefault(e => e.AttributeClass.Name.Equals(Shared.DependencyPropertiesAttributeString, StringComparison.Ordinal)) != null);

                if (dependencyInterfaces.Count() > 0)
                    builder.AppendLine($@"
        // ----- dependency properties -----");

                foreach (var inter in dependencyInterfaces)
                {
                    var properties = inter
                        .GetMembers()
                        .Where(e => e.Kind == SymbolKind.Property);

                    foreach (var prop in properties)
                        GeneratePropertyForField((IPropertySymbol)prop);
                }
            }
        }

        IPropertySymbol FindInBasePropertySymbolWithName(string propertyName)
        {
            IPropertySymbol propertySymbol = null;
            Helpers.LoopDownToObject(mainSymbol.BaseType, type =>
            {
                propertySymbol = (IPropertySymbol)(type.GetMembers(propertyName).FirstOrDefault());
                return propertySymbol != null;
            });
            return propertySymbol;
        }

        void GeneratePropertyForField(IPropertySymbol propertySymbol)
        {
            var name = propertySymbol.Name;
            var typeName = propertySymbol.Type.ToDisplayString();
            var callback = GetPropertyCallback(propertySymbol);
            var defaultValueString = GetDefaultValueString(propertySymbol, typeName);

            var newKeyword = FindInBasePropertySymbolWithName(name) != null ? " new" : "" ;
            callback = callback != null ? $", {callback}" : "";

            builder.Append($@"

        public static{newKeyword} readonly Microsoft.UI.Xaml.DependencyProperty {name}Property =
            Microsoft.UI.Xaml.DependencyProperty.Register(nameof({name}), 
            typeof({typeName}), 
            typeof({mainSymbol.ToDisplayString()}), 
            new Microsoft.UI.Xaml.PropertyMetadata({(defaultValueString != null ? $"({typeName}){defaultValueString}" : $"default({typeName})")}{callback}));

        public{newKeyword} {typeName} {name}
        {{
            get => ({typeName})GetValue({name}Property);
            set => SetValue({name}Property, value);
        }}
        ");
        }
    }
}