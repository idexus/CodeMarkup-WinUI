using Microsoft.UI.Xaml;

namespace CodeMarkup.WinUI.HotReload
{
    internal class PageInFrameHotReloadHandler : IHotReloadHandler
    {
        public bool ReplaceVisualElement(FrameworkElement oldElement, FrameworkElement newElement)
        {
            if (oldElement is Microsoft.UI.Xaml.Controls.Page oldPage &&
                oldPage.Parent is Microsoft.UI.Xaml.Controls.Frame parent &&
                newElement is Microsoft.UI.Xaml.Controls.Page newPage)
            {
                parent.Content = newPage;
                return true;
            }
            return false;
        }
    }
}
