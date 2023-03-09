using Microsoft.UI.Xaml;
using System.Collections.Generic;
using CodeOnly.WinUI.Core.Internal;

namespace CodeOnly.WinUI.Core
{    
    public static partial class BindableObjectExtension
    {
        public static T SetValueOrAddSetter<T>(this T self, DependencyProperty property, object value) where T : DependencyObject
        {
            var setters = FluentStyling.Setters as IList<SetterBase>;
            if (setters != null)
                setters.Add(new Setter { Property = property, Value = value });
            else
                self.SetValue(property, value);
            return self;
        }
    }
}