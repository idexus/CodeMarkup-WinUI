using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections;
using System.Collections.Generic;

namespace CodeMarkup.WinUI
{

    public static partial class IEnumerableExtension
	{
        public static void Add<T>(this T self, Func<T, T> configure)
            where T : DependencyObject, IEnumerable
        {
            configure(self);
        }

        public static void Add<T, Q>(this T self, IEnumerable<Q> enumerable)
            where T : IUIElementContainer
            where Q : UIElement
        {
                if (enumerable is UIElement subContainer)
                    self.Add(subContainer);
                else
                {
                    foreach (var item in enumerable)
                        self.Add(item);
                }
            }
    }
}
