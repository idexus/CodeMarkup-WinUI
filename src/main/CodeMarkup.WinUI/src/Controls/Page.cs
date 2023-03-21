using CodeMarkup.WinUI.HotReload;
using Microsoft.UI.Xaml;
using System.ComponentModel;
using Windows.UI.ViewManagement;

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
