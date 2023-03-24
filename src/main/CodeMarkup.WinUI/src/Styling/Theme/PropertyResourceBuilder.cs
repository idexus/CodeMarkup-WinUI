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
        class ConverterParameter
        {
            public string Key { get; set; }
            public FrameworkElement Source { get; set; }
        }

        class DictionaryKeyConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, string language)
            {
                if (value is FrameworkElement element && parameter is ConverterParameter converterParameter)
                {
                    object result;
                    if (converterParameter.Source == null)
                    {
                        Application.Current.Resources.TryGetValue(converterParameter.Key, out result);
                        if (result == null) element.Resources.TryGetValue(converterParameter.Key, out result);
                    }
                    else
                    {
                        element.Resources.TryGetValue(converterParameter.Key, out result);
                        if (result == null) Application.Current.Resources.TryGetValue(converterParameter.Key, out result);
                    }
                    
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
                if (Context.Element is FrameworkElement contextElement)
                {                    
                    var element = source ?? contextElement;
                    var manager = element.GetValue(ThemeResourcesManager.DefaultManagerProperty);
                    if (manager == null)
                    {
                        manager = new ThemeResourcesManager { AttachedTo = element };
                        element.SetValue(ThemeResourcesManager.DefaultManagerProperty, manager);
                    }

                    contextElement.SetBinding(
                        dp: Context.Property,
                        binding: new Binding
                        {
                            Path = new PropertyPath(nameof(ThemeResourcesManager.AttachedTo)),
                            Mode = Microsoft.UI.Xaml.Data.BindingMode.OneWay,
                            Converter = new DictionaryKeyConverter(),
                            ConverterParameter = new ConverterParameter { Key = key, Source = source },
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
