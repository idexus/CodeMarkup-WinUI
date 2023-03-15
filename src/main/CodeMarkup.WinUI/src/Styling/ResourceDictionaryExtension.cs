using Microsoft.UI.Xaml;
using System.Collections.Generic;

namespace CodeMarkup.WinUI.Styling
{

    public static partial class ResourceDictionaryExtension
    {
        public static void Add<T>(this ResourceDictionary self, Style<T> style) where T : FrameworkElement
        {
            self[typeof(T)] = (Style)style;       
        }

        public static void Add(this ResourceDictionary self, ThemeColor themeColor)
        {
            if (!self.ThemeDictionaries.ContainsKey("Light")) self.ThemeDictionaries["Light"] = new ResourceDictionary();
            if (!self.ThemeDictionaries.ContainsKey("Dark")) self.ThemeDictionaries["Dark"] = new ResourceDictionary();
            var lightDictionary = self.ThemeDictionaries["Light"] as ResourceDictionary;
            var darkDictionary = self.ThemeDictionaries["Dark"] as ResourceDictionary;
            lightDictionary[themeColor.Key] = themeColor.Light;
            darkDictionary[themeColor.Key] = themeColor.Dark;
        }
    }
}
