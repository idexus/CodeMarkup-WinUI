using CodeMarkup.WinUI.Controls;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Media;
using System;
using Windows.UI;
using Windows.UI.ViewManagement;

namespace CodeMarkup.WinUI.Styling
{
    public sealed class PropertyResourceBuilder<T> : IPropertyBuilder<T>
    {
        class DictionaryKeyConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, string language)
            {
                if (parameter is string key)
                {
                    object result = null;
                    if (value is ResourceDictionary dictionary) dictionary.TryGetValue(key, out result);
                    if (result == null) Application.Current.Resources.TryGetValue(key, out result);
                    
                    if (result is Windows.UI.Color color)
                        return new SolidColorBrush(color);

                    return result;
                }
                return null;
            }

            public object ConvertBack(object value, Type targetType, object parameter, string language)
            {
                throw new NotImplementedException();
            }
        }

        public PropertyContext<T> Context { get; set; }

        string key = null;
        FrameworkElement source = null;

        public PropertyResourceBuilder(PropertyContext<T> context)
        {
            Context = context;
        }

        public bool Build()
        {
            if (key != null)
            {
                if (Context.Element is FrameworkElement element)
                {
                    var resourceSource = source ?? element;
                    var manager = resourceSource.GetValue(ThemeResourcesManager.DefaultManagerProperty);
                    if (manager == null)
                    {
                        manager = new ThemeResourcesManager { Element = resourceSource };
                        resourceSource.SetValue(ThemeResourcesManager.DefaultManagerProperty, manager);
                    }

                    element.SetBinding(
                        dp: Context.Property,
                        binding: new Binding
                        {
                            Path = new PropertyPath(nameof(ThemeResourcesManager.AttachedResources)),
                            Mode = Microsoft.UI.Xaml.Data.BindingMode.OneWay,
                            Converter = new DictionaryKeyConverter(),
                            ConverterParameter = key,
                            ConverterLanguage = null,
                            Source = manager
                        });
                    return true;
                }
            }
            return false;
        }

        internal PropertyResourceBuilder<T> ResourceKey(string key) { this.key = key; return this; }
        public PropertyResourceBuilder<T> Source(FrameworkElement source) { this.source = source; return this; }
    }
}
