using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;


namespace CodeOnly.WinUI
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
            self.SetValueOrAddSetter(Microsoft.UI.Xaml.Controls.Grid.ColumnSpanProperty, column);
            self.SetValueOrAddSetter(Microsoft.UI.Xaml.Controls.Grid.RowSpanProperty, row);
            return self;
        }

        public static T AddVisualStateList<T>(this T self, List<VisualState> visualStates)
            where T : Microsoft.UI.Xaml.FrameworkElement
        {
            return self.AddVisualStateList(null, visualStates);
        }

        public static T AddVisualStateList<T>(this T self, string name, List<VisualState> visualStates)
            where T : Microsoft.UI.Xaml.FrameworkElement
        {
            VisualStateGroup visualStateGroup = new();
            if (name != null) visualStateGroup.SetValue(FrameworkElement.NameProperty, name);
            foreach (VisualState visualState in visualStates)
                visualStateGroup.States.Add(visualState);
            VisualStateManager.GetVisualStateGroups(self).Add(visualStateGroup);
            return self;
        }
    }
}
