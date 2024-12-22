using CodeMarkup.WinUI.HotReload;

namespace CodeMarkup.WinUI
{
    [CodeMarkup]
    [ContainerProperty(nameof(MenuItems))]
    public partial class NavigationView : Microsoft.UI.Xaml.Controls.NavigationView { }

    [CodeMarkup]
    [ContainerProperty(nameof(MenuItems))]
    public partial class NavigationViewItem : Microsoft.UI.Xaml.Controls.NavigationViewItem { }
}
