namespace CodeMarkup.WinUI.Controls
{
    [MarkupObject]
    [ContainerProperty(nameof(Content))]
    public partial class Button : Microsoft.UI.Xaml.Controls.Button { }

    [MarkupObject]
    [ContainerProperty(nameof(Flyout))]
    public partial class DropDownButton : Microsoft.UI.Xaml.Controls.DropDownButton { }

    [MarkupObject]
    [ContainerProperty(nameof(Items))]
    public partial class ComboBox : Microsoft.UI.Xaml.Controls.ComboBox { }
}
