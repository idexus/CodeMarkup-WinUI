using CodeMarkup.WinUI.Controls;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Media;
using System;
using Windows.UI.ViewManagement;

namespace CodeMarkup.WinUI.Styling
{
    public sealed class PropertyThemeBuilder<T> : IPropertyBuilder<T>
    {
        class DictionaryKeyConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, string language)
            {
                if (value is ResourceDictionary dictionary && parameter is string key)
                {
                    var obj = dictionary[key];
                    if (obj is Windows.UI.Color color)
                        return new SolidColorBrush(color);
                    return obj;
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

        public PropertyThemeBuilder(PropertyContext<T> context)
        {
            Context = context;
        }

        public bool Build()
        {
            if (key != null && source != null)
            {
                if (Context.Element is FrameworkElement element)
                {
                    var manager = source.GetValue(ThemeResourcesManager.DefaultManagerProperty);
                    if (manager == null)
                    {
                        manager = new ThemeResourcesManager { Element = source };
                        source.SetValue(ThemeResourcesManager.DefaultManagerProperty, manager);
                    }

                    element.SetBinding(
                        dp: Context.Property,
                        binding: new Binding
                        {                           
                            Path = new PropertyPath("ThemeResources"),
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

        internal PropertyThemeBuilder<T> ResourceKey(string key) { this.key = key; return this; }
        public PropertyThemeBuilder<T> Source(FrameworkElement source) { this.source = source; return this; }
    }
}
