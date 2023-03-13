using CodeMarkup.WinUI.HotReload;

namespace CodeMarkup.WinUI.Controls
{
    [MarkupObject]
    [ContainerProperty(nameof(Content))]
    public partial class Page : Microsoft.UI.Xaml.Controls.Page
    {
        public Page()
        {
            HotReloadContext.Handler?.Invoke(this);
        }
    }
}
