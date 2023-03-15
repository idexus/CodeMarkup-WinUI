using CodeMarkup.WinUI.HotReload;

namespace CodeMarkup.WinUI.Controls
{
    [MarkupObject]
    [ContainerProperty(nameof(MenuItems))]
    public partial class NavigationView : Microsoft.UI.Xaml.Controls.NavigationView { }

    [MarkupObject]
    [ContainerProperty(nameof(MenuItems))]
    public partial class NavigationViewItem : Microsoft.UI.Xaml.Controls.NavigationViewItem { }
}
