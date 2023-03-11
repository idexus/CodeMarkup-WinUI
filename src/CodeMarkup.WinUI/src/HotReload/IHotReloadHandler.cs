
using Microsoft.UI.Xaml;

namespace CodeMarkup.WinUI.HotReload
{
    public interface IHotReloadHandler
    {
        public bool ReplaceVisualElement(FrameworkElement oldElement, FrameworkElement newElement);
    }
}
