namespace CodeMarkup.WinUI.Controls
{
    [CodeMarkup]
    [ContainerProperty(nameof(Children))]
    public partial class Grid : Microsoft.UI.Xaml.Controls.Grid { }

    [CodeMarkup]
    [ContainerProperty(nameof(Children))]
    public partial class StackPanel : Microsoft.UI.Xaml.Controls.StackPanel { }

    [CodeMarkup]
    [ContainerProperty(nameof(Children))]
    public partial class VStack : Microsoft.UI.Xaml.Controls.StackPanel 
    { 
        public VStack() { Orientation = Microsoft.UI.Xaml.Controls.Orientation.Vertical; }
    }

    [CodeMarkup]
    [ContainerProperty(nameof(Children))]
    public partial class HStack : Microsoft.UI.Xaml.Controls.StackPanel
    {
        public HStack() { Orientation = Microsoft.UI.Xaml.Controls.Orientation.Horizontal; }
    }
}
