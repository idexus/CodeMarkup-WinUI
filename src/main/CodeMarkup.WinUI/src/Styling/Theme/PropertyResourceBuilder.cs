using CodeMarkup.WinUI.Controls;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Media;
using System;
using System.Collections.Generic;
using System.Xml.Linq;
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

        void SetPropertyValue()
        {   
            object result;
            if (source == null)
            {
                Application.Current.Resources.TryGetValue(key, out result);
                if (result == null) (Context.Element as FrameworkElement)?.Resources.TryGetValue(key, out result);
            }
            else
            {
                source.Resources.TryGetValue(key, out result);
                if (result == null) Application.Current.Resources.TryGetValue(key, out result);
            }

            if (result is Windows.UI.Color color)
                result = new SolidColorBrush(color);

            Context.Element.SetValue(Context.Property, result);
        }

        public bool Build()
        {
            if (key != null)
            {
                if (Context.Element is FrameworkElement contextElement)
                {
                    SetPropertyValue();
                    ResourcesManager.ThemeChanged += ResourcesManager_ThemeChanged;

                    return true;
                }
            }
            return false;
        }

        private void ResourcesManager_ThemeChanged()
        {
            Context.Element.DispatcherQueue.TryEnqueue(() =>
            {
                if (Context.Element is FrameworkElement element)
                {
                    if (element.Parent == null)
                        RemoveHandler();
                    else
                        SetPropertyValue();
                }
                else
                    RemoveHandler();
            });
        }

        private void RemoveHandler()
        {
            ResourcesManager.ThemeChanged -= ResourcesManager_ThemeChanged;
        }

        internal PropertyResourceBuilder<T> ResourceKey(string key) { this.key = key; return this; }
        public PropertyResourceBuilder<T> Source(FrameworkElement source) { this.source = source; return this; }
    }
}
