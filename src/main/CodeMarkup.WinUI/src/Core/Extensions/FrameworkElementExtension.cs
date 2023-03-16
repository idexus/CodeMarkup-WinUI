using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Shapes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;


namespace CodeMarkup.WinUI
{
    [AttachedProperties(typeof(Microsoft.UI.Xaml.Controls.Grid))]
    public interface IFrameworkElementGridAttachedProperties
    {
        int Column { get; set; }
        int Row { get; set; }
        int ColumnSpan { get; set; }
        int RowSpan { get; set; }
    }


    [AttachedInterfaces(typeof(Microsoft.UI.Xaml.FrameworkElement), new[] { typeof(IFrameworkElementGridAttachedProperties) })]
    public static partial class FrameworkElementExtension
    {
        public static T GridSpan<T>(this T self, int column = 1, int row = 1) where T : FrameworkElement
        {
            self.SetValue(Microsoft.UI.Xaml.Controls.Grid.ColumnSpanProperty, column);
            self.SetValue(Microsoft.UI.Xaml.Controls.Grid.RowSpanProperty, row);
            return self;
        }

        public static T Size<T>(this T self, double width, double height) where T : FrameworkElement
        {
            self.SetValue(FrameworkElement.WidthProperty, width);
            self.SetValue(FrameworkElement.HeightProperty, height);
            return self;
        }
    }
}
