using Microsoft.UI.Xaml;

namespace CodeMarkup.WinUI
{
    public sealed class PropertyContext<T>
    {
        public PropertyContext(DependencyObject element, DependencyProperty property)
        {
            Element = element;
            Property = property;
        }

        public DependencyObject Element { get; set; }
        public DependencyProperty Property { get; set; }
    }
}
