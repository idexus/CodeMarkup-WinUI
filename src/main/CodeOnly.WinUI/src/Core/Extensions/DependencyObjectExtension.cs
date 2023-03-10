using Microsoft.UI.Xaml;
using System.Collections.Generic;
using CodeOnly.WinUI.Internal;
using Microsoft.UI.Xaml.Controls;
using System;

namespace CodeOnly.WinUI
{    
    public static partial class DependencyObjectExtension
    {
        public static T SetValueOrAddSetter<T>(this T self, DependencyProperty property, object value) 
            where T : DependencyObject
        {
            var setters = FluentStyling.Setters;
            if (setters != null)
                setters.Add(new Setter { Property = property, Value = value });
            else
                self.SetValue(property, value);
            return self;
        }

        public static T Assign<T>(this T self, out T obj) where T : DependencyObject { obj = self; return obj; }
        public static T InvokeOnElement<T>(this T self, Action<T> action) where T : DependencyObject { action(self); return self; }
    }
}
