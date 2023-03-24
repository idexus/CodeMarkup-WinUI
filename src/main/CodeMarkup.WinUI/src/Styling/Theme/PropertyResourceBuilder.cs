using CodeMarkup.WinUI.Controls;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Media;
using System;
using System.Collections.Generic;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.ViewManagement;

namespace CodeMarkup.WinUI.Styling
{
    public sealed class PropertyResourceBuilder<T> : IPropertyBuilder<T>
    {
        public PropertyContext<T> Context { get; set; }

        string key = null;
        FrameworkElement source = null;

        public PropertyResourceBuilder(PropertyContext<T> context)
        {
            Context = context;
        }

        static void SetPropertyValue(PropertyContext<T> context, FrameworkElement source, string key)
        {   
            object result;
            if (source == null)
            {
                Application.Current.Resources.TryGetValue(key, out result);
                if (result == null) (context.Element as FrameworkElement)?.Resources.TryGetValue(key, out result);
            }
            else
            {
                source.Resources.TryGetValue(key, out result);
                if (result == null) Application.Current.Resources.TryGetValue(key, out result);
            }

            if (result is Windows.UI.Color color)
                result = new SolidColorBrush(color);

            context.Element.SetValue(context.Property, result);
        }

        public bool Build()
        {
            if (key != null)
            {
                if (Context.Element is FrameworkElement contextElement)
                {
                    var uiSettings = contextElement.GetValue(ThemeResourcesManager.UISettingsProperty) as UISettings;
                    if (uiSettings == null)
                    {
                        uiSettings = new UISettings();
                        contextElement.SetValue(ThemeResourcesManager.UISettingsProperty, new UISettings());
                    }

                    SetPropertyValue(Context, source, key);
                    uiSettings.ColorValuesChanged += ColorChangedCallback;

                    return true;
                }
            }
            return false;
        }

        private void ColorChangedCallback(UISettings settings, object args)
        {
            if (Context.Element is FrameworkElement contextElement)
            {
                contextElement.DispatcherQueue.TryEnqueue(() => 
                {
                    if (contextElement == null)
                        settings.ColorValuesChanged -= ColorChangedCallback;
                    else
                        SetPropertyValue(Context, source, key);
                });
            }
        }

        internal PropertyResourceBuilder<T> ResourceKey(string key) { this.key = key; return this; }
        public PropertyResourceBuilder<T> Source(FrameworkElement source) { this.source = source; return this; }
    }
}
