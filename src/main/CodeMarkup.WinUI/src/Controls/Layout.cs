namespace CodeMarkup.WinUI.Controls
{
    [MarkupObject]
    [ContainerProperty(nameof(Children))]
    public partial class Grid : Microsoft.UI.Xaml.Controls.Grid { }

    [MarkupObject]
    [ContainerProperty(nameof(Children))]
    public partial class StackPanel : Microsoft.UI.Xaml.Controls.StackPanel { }

    [MarkupObject]
    [ContainerProperty(nameof(Children))]
    public partial class VStack : Microsoft.UI.Xaml.Controls.StackPanel 
    { 
        public VStack() { Orientation = Microsoft.UI.Xaml.Controls.Orientation.Vertical; }
    }

    [MarkupObject]
    [ContainerProperty(nameof(Children))]
    public partial class HStack : Microsoft.UI.Xaml.Controls.StackPanel
    {
        public HStack() { Orientation = Microsoft.UI.Xaml.Controls.Orientation.Horizontal; }
    }

    [MarkupObject]
    [ContainerProperty(nameof(Content))]
    public partial class Expander : Microsoft.UI.Xaml.Controls.Expander { }

    [MarkupObject]
    [ContainerProperty(nameof(Children))]
    public partial class Canvas : Microsoft.UI.Xaml.Controls.Canvas { }
}
