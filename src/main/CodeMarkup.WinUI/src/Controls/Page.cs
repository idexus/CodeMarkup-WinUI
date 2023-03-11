using CodeMarkup.WinUI.HotReload;

namespace CodeMarkup.WinUI.Controls
{
    [CodeMarkup]
    [ContainerProperty(nameof(Content))]
    public partial class Page : Microsoft.UI.Xaml.Controls.Page
    {
        public Page()
        {
            HotReloadContext.Handler?.Invoke(this);
        }
    }
}
