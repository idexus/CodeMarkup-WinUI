using System;
using System.Linq;
using Microsoft.CodeAnalysis;

namespace CodeOnly.WinUI.Generator
{
	public class Shared
	{
        public const string WinUIPrefix = "Microsoft.UI.Xaml";
        public const string LibPrefix = "CodeOnly.WinUI";

        public const string DependencyObjectName = "Microsoft.UI.Xaml.DependencyObject";

        public static string[] NotGenerateList = { "this[]" };

        public const string ContentPropertyAttributeString = "ContentPropertyAttribute";
        public const string DependencyPropertiesAttributeString = "DependencyPropertiesAttribute";
        public const string SharpObjectAttributeString = "SharpObjectAttribute";
        public const string AttachedPropertiesAttributeString = "AttachedPropertiesAttribute";
        public const string AttachedInterfacesAttributeString = "AttachedInterfacesAttribute";
        public const string AttachedNameAttributeString = "AttachedNameAttribute";
        public const string DefaultValueAttributeString = "DefaultValueAttribute";
        public const string PropertyCallbackAttributeString = "PropertyCallbacksAttribute";

        public static AttributeData GetAttachedInterfacesAttributeData(INamedTypeSymbol symbol)
        {
            var attributes = symbol.GetAttributes();
            return attributes.FirstOrDefault(e => e.AttributeClass.Name.Equals(AttachedInterfacesAttributeString));
        }

        public static string GetAttachedPropertyName(IPropertySymbol symbol)
        {
            var attributes = symbol.GetAttributes();
            var attributeData = attributes.FirstOrDefault(e => e.AttributeClass.Name.Equals(AttachedNameAttributeString));
            if (attributeData != null) return (string)attributeData.ConstructorArguments[0].Value;
            return $"{symbol.Name}Property";
        }

        public static bool IsDependencyObject(INamedTypeSymbol symbol)
        {
            var isBindable = false;

            Helpers.LoopDownToObject(symbol, type =>
            {
                if (type.ToDisplayString().Equals(DependencyObjectName, StringComparison.Ordinal)) isBindable = true;
                return isBindable;
            });

            return isBindable;
        }
    }
}
