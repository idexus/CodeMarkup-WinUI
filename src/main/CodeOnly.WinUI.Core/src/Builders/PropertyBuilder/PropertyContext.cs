using Microsoft.UI.Xaml;

namespace CodeOnly.WinUI.Core
{
    public sealed class PropertyContext<T>
    {
        public PropertyContext(UIElement element, DependencyProperty property)
        {
            Element = element;
            Property = property;
        }

        public UIElement Element { get; set; }
        public DependencyProperty Property { get; set; }
    }
}
