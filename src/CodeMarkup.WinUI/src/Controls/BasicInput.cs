namespace CodeMarkup.WinUI.Controls
{
    [CodeMarkup]
    public partial class Button : Microsoft.UI.Xaml.Controls.Button { }

    [CodeMarkup]
    [ContainerProperty(nameof(Flyout))]
    public partial class DropDownButton : Microsoft.UI.Xaml.Controls.DropDownButton { }

    [CodeMarkup]
    [ContainerProperty(nameof(Items))]
    public partial class MenuFlyout : Microsoft.UI.Xaml.Controls.MenuFlyout { }

    [CodeMarkup]
    public partial class MenuFlyoutItem : Microsoft.UI.Xaml.Controls.MenuFlyoutItem { }

}
