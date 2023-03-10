using System;
using System.Collections.Generic;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Data;

namespace CodeOnly.WinUI.Core
{
    [Bindable]
    public class ControlTemplateHandler
    {
        internal static Dictionary<string, Action<FrameworkElement, Panel>> HandlerMethods = new Dictionary<string, Action<FrameworkElement, Panel>>();

        // TemplatedParent

        public static readonly DependencyProperty TemplatedParentProperty =
            DependencyProperty.RegisterAttached("TemplatedParent",
            typeof(FrameworkElement),
            typeof(ControlTemplateHandler),
            new PropertyMetadata(default(FrameworkElement), TemplatedParentCallback));

        public static void SetTemplatedParent(DependencyObject obj, FrameworkElement value)
        {
            obj.SetValue(TemplatedParentProperty, value);
        }

        public static FrameworkElement GetTemplatedParent(DependencyObject obj)
        {
            return (FrameworkElement)obj.GetValue(TemplatedParentProperty);
        }

        private static void TemplatedParentCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var handlerId = d.GetValue(MethodIdProperty) as string;
            if (handlerId != null && d is Panel panel)
            {
                if (HandlerMethods.TryGetValue(handlerId, out var handler))
                {
                    handler(e.NewValue as FrameworkElement, panel);
                }
            }
        }

        // MethodId

        public static readonly DependencyProperty MethodIdProperty =
            DependencyProperty.RegisterAttached("MethodId",
            typeof(string),
            typeof(ControlTemplateHandler),
            new PropertyMetadata(default(string)));

        public static void SetMethodId(DependencyObject obj, string value)
        {
            obj.SetValue(MethodIdProperty, value);
        }

        public static string GetMethodId(DependencyObject obj)
        {
            return (string)obj.GetValue(MethodIdProperty);
        }
    }
}
