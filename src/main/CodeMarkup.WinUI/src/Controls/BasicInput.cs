namespace CodeMarkup.WinUI.Controls
{
    [CodeMarkup]
    [ContainerProperty(nameof(Content))]
    public partial class Button : Microsoft.UI.Xaml.Controls.Button { }

    [CodeMarkup]
    [ContainerProperty(nameof(Flyout))]
    public partial class DropDownButton : Microsoft.UI.Xaml.Controls.DropDownButton { }

    [CodeMarkup]
    [ContainerProperty(nameof(Items))]
    public partial class ComboBox : Microsoft.UI.Xaml.Controls.ComboBox { }
}
