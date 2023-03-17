using System;
using System.Collections.Generic;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Data;

namespace CodeMarkup.WinUI
{
    [Bindable]
    public class FrameworkTempateManager
    {
        internal static Dictionary<string, Action<FrameworkElement, FrameworkElement>> HandlerMethodsWithParent = new Dictionary<string, Action<FrameworkElement, FrameworkElement>>();
        internal static Dictionary<string, Action<FrameworkElement>> HandlerMethodsWithoutParent = new Dictionary<string, Action<FrameworkElement>>();

        // TemplatedParent

        public static readonly DependencyProperty TemplatedParentProperty =
            DependencyProperty.RegisterAttached("TemplatedParent",
            typeof(FrameworkElement),
            typeof(FrameworkTempateManager),
            new PropertyMetadata(default(FrameworkElement), TemplatedParentCallback));

        public static void SetTemplatedParent(DependencyObject obj, FrameworkElement value)
        {
            obj.SetValue(TemplatedParentProperty, value);
        }

        public static FrameworkElement GetTemplatedParent(DependencyObject obj)
        {
            return (FrameworkElement)obj.GetValue(TemplatedParentProperty);
        }

        private static void TemplatedParentCallback(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            if (obj is FrameworkElement root &&
                args.NewValue is FrameworkElement parent &&
                root.GetValue(MethodIdProperty) is string handlerId &&
                HandlerMethodsWithParent.TryGetValue(handlerId, out var handlerMethod))
            {
                handlerMethod(root, parent);
            }
        }

        // MethodId

        public static readonly DependencyProperty MethodIdProperty =
            DependencyProperty.RegisterAttached("MethodId",
            typeof(string),
            typeof(FrameworkTempateManager),
            new PropertyMetadata(default(string), MethodIdCallback));

        public static void SetMethodId(DependencyObject obj, string value)
        {
            obj.SetValue(MethodIdProperty, value);
        }

        public static string GetMethodId(DependencyObject obj)
        {
            return (string)obj.GetValue(MethodIdProperty);
        }

        private static void MethodIdCallback(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            if (obj is FrameworkElement root &&
                args.NewValue is string handlerId &&
                HandlerMethodsWithoutParent.TryGetValue(handlerId, out var handlerMethod))
            {
                handlerMethod(root);
            }
        }
    }
}
