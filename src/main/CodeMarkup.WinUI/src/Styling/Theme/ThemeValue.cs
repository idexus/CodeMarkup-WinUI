using Windows.UI;

namespace CodeMarkup.WinUI.Styling
{
    public class ThemeValue<T>
    {
        public string Key { get; set; } 
        public T Light { get; set; }
        public T Dark { get; set; }
    }
}
