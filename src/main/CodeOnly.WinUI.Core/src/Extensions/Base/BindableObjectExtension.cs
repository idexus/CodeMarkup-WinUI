using Microsoft.UI.Xaml;
using System.Collections.Generic;
using CodeOnly.WinUI.Core.Internal;

namespace CodeOnly.WinUI.Core
{    
    public static partial class BindableObjectExtension
    {
        public static T SetValueOrAddSetter<T>(this T self, DependencyProperty property, object value) where T : DependencyObject
        {
            var setters = FluentStyling.Setters as IList<Setter>;
            if (setters != null)
                setters.Add(new Setter { Property = property, Value = value });
            else
                self.SetValue(property, value);
            return self;
        }

        /*
        public static T Bind<T>(this T self,
            BindableProperty property,
            string sourcePath,
            BindingMode mode = BindingMode.Default,
            IValueConverter converter = null,
            string converterParameter = null,
            string stringFormat = null,
            object source = null) where T : BindableObject
        {
            self.SetBinding(
                targetProperty: property,
                binding: new Binding(
                    path: sourcePath,
                    mode: mode,
                    converter: converter,
                    converterParameter: converterParameter,
                    stringFormat: stringFormat,
                    source: source));
            return self;
        }

        public static T BindTemplatedParent<T>(this T self,
            BindableProperty property,
            string sourcePath,
            BindingMode mode = BindingMode.Default,
            IValueConverter converter = null,
            string converterParameter = null,
            string stringFormat = null) where T : BindableObject
        {
            self.SetBinding(
                targetProperty: property,
                binding: new Binding(
                    path: sourcePath,
                    mode: mode,
                    converter: converter,
                    converterParameter: converterParameter,
                    stringFormat: stringFormat,
                    source: RelativeBindingSource.TemplatedParent));
            return self;
        }

        public static T RegisterName<T>(this T self, string name, BindableObject scopedElement) where T : BindableObject
        {
            var nameScope = NameScope.GetNameScope(scopedElement);
            if (nameScope == null)
            {
                nameScope = new NameScope();
                NameScope.SetNameScope(scopedElement, nameScope);
            }
            nameScope.RegisterName(name, self);
            return self;
        }
        */
    }
}