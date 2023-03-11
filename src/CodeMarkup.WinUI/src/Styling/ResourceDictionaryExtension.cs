using Microsoft.UI.Xaml;

namespace CodeMarkup.WinUI.Styling
{
    public static partial class ResourceDictionaryExtension
    {
        public static void Add<T>(this ResourceDictionary self, Style<T> style) where T : FrameworkElement
        {
            self[typeof(T)] = (Style)style;       
        }
    }
}
