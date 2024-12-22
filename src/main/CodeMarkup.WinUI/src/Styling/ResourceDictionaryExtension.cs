using Microsoft.UI.Xaml;
using System.Collections.Generic;

namespace CodeMarkup.WinUI
{

    public static partial class ResourceDictionaryExtension
    {
        public static void Add<T>(this ResourceDictionary self, Style<T> style) where T : FrameworkElement
        {
            self[typeof(T)] = (Style)style;       
        }

        public static void Add<T>(this ResourceDictionary self, ThemeValue<T> themeValue)
        {
            if (!self.ThemeDictionaries.ContainsKey("Light")) self.ThemeDictionaries["Light"] = new ResourceDictionary();
            if (!self.ThemeDictionaries.ContainsKey("Dark")) self.ThemeDictionaries["Dark"] = new ResourceDictionary();
            var lightDictionary = self.ThemeDictionaries["Light"] as ResourceDictionary;
            var darkDictionary = self.ThemeDictionaries["Dark"] as ResourceDictionary;
            lightDictionary[themeValue.Key] = themeValue.Light;
            darkDictionary[themeValue.Key] = themeValue.Dark;
        }
    }
}
