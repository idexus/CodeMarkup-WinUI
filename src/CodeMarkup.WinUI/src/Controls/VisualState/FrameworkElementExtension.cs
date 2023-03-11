﻿using Microsoft.UI.Xaml;
using System.Collections.Generic;

namespace CodeMarkup.WinUI.Controls
{
    public static partial class FrameworkElementExtension
    {
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