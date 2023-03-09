using Microsoft.UI.Xaml;
using System;

namespace CodeOnly.WinUI.Core
{
    public static class PublicExtension
    {
        public static T Assign<T>(this T self, out T obj) where T : DependencyObject { obj = self; return obj; }
        public static T InvokeOnElement<T>(this T self, Action<T> action) where T : DependencyObject { action(self); return self; }
    }
}
