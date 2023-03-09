﻿using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;


namespace CodeOnly.WinUI.Core
{
    public static partial class FrameworkElementExtension
    {
        public static T AddVisualStateGroup<T>(this T self, List<VisualState> visualStates)
            where T : Microsoft.UI.Xaml.FrameworkElement
        {
            return self.AddVisualStateGroup(null, visualStates);
        }

        public static T AddVisualStateGroup<T>(this T self, string name, List<VisualState> visualStates)
            where T : Microsoft.UI.Xaml.FrameworkElement
        {
            VisualStateGroup visualStateGroup = new();
            if (name != null) visualStateGroup.SetValue(FrameworkElement.NameProperty, name);
            foreach (VisualState visualState in visualStates)
                visualStateGroup.States.Add(visualState);
            VisualStateManager.GetVisualStateGroups(self).Add(visualStateGroup);
            return self;
        }

        //public static T Name<T>(this T self, string name)
        //    where T : Microsoft.UI.Xaml.FrameworkElement
        //{
        //    self.SetValue(FrameworkElement.NameProperty, name);
        //    return self;
        //}
    }


        /*
        [AttachedProperties(typeof(Microsoft.Maui.Controls.SemanticProperties))]
        public interface IVisualElementSemanticProperties
        {
            [AttachedName("HintProperty")]
            string SemanticHint { get; set; }

            [AttachedName("DescriptionProperty")]
            string SemanticDescription { get; set; }

            [AttachedName("HeadingLevelProperty")]
            SemanticHeadingLevel SemanticHeadingLevel { get; set; }
        }

        [AttachedProperties(typeof(Microsoft.Maui.Controls.AutomationProperties))]
        public interface IVisualElementAutomationProperties
        {
            [AttachedName("ExcludedWithChildrenProperty")]
            bool? AutomationExcludedWithChildren { get; set; }

            [AttachedName("IsInAccessibleTreeProperty")]
            bool? AutomationIsInAccessibleTree { get; set; }

            [AttachedName("NameProperty")]
            string AutomationName { get; set; }

            [AttachedName("HelpTextProperty")]
            string AutomationHelpText { get; set; }

            [AttachedName("LabeledByProperty")]
            Microsoft.Maui.Controls.VisualElement AutomationLabeledBy { get; set; }
        }

        [AttachedProperties(typeof(Microsoft.Maui.Controls.VisualStateManager))]
        public interface IVisualElementVisualStateGroupsAttachedProperties
        {
            Microsoft.Maui.Controls.VisualStateGroupList VisualStateGroups { get; set; }
        }

        [SharpObject()]
        [AttachedInterfaces(typeof(Microsoft.Maui.Controls.VisualElement),
            new[] 
            { 
                typeof(IVisualElementVisualStateGroupsAttachedProperties), 
                typeof(IVisualElementAutomationProperties), 
                typeof(IVisualElementSemanticProperties) 
            })]
        public static partial class VisualElementExtension
        {
            // ------------

            public static T SizeRequest<T>(this T self, double widthRequest, double heightRequest)
                where T : VisualElement
            {
                self.SetValueOrAddSetter(VisualElement.WidthRequestProperty, widthRequest);
                self.SetValueOrAddSetter(VisualElement.HeightRequestProperty, heightRequest);
                return self;
            }

            public static Task<bool> AnimateSizeRequestTo<T>(this T self, double width, double height, uint length = 250, Easing easing = null)
                where T : VisualElement
            {
                Size from = new Size(self.WidthRequest, self.HeightRequest);
                Size to = new Size(width, height);
                var transform = (double t) => Transformations.SizeTransform(from, to, t);
                var callback = (Size value) => { self.SizeRequest(value.Width, value.Height); };
                return Transformations.AnimateAsync<Size>(self, "AnimateSizeRequestTo", transform, callback, length, easing);
            }
        }
        */
    }
