using Windows.UI;

namespace CodeMarkup.WinUI
{
    public class ThemeValue<T>
    {
        public string Key { get; set; } 
        public T Light { get; set; }
        public T Dark { get; set; }
    }
}
