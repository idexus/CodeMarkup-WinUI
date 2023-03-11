using Microsoft.UI.Xaml;
using System.Collections.Generic;
using CodeMarkup.WinUI.Internal;
using Microsoft.UI.Xaml.Controls;
using System;

namespace CodeMarkup.WinUI
{    
    public static partial class DependencyObjectExtension
    {
        public static T Assign<T>(this T self, out T obj) where T : DependencyObject { obj = self; return obj; }
        public static T InvokeOnElement<T>(this T self, Action<T> action) where T : DependencyObject { action(self); return self; }
    }
}
