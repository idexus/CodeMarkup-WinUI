using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections;

namespace CodeMarkup.WinUI.Controls
{
	public static partial class IEnumerableExtension
	{
        public static void Add<T>(this T self, Func<T, T> configure)
            where T : DependencyObject, IEnumerable
        {
            configure(self);
        }

        public static void Add<T>(this T self, Action<T> configure)
            where T : Panel, IEnumerable
        {
            configure(self);
        }
    }
}
