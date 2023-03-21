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

    [CodeMarkup]
    [ContainerProperty(nameof(Content))]
    public partial class Expander : Microsoft.UI.Xaml.Controls.Expander { }

    [CodeMarkup]
    [ContainerProperty(nameof(Children))]
    public partial class Canvas : Microsoft.UI.Xaml.Controls.Canvas { }

    [CodeMarkup]
    [ContainerProperty(nameof(Items))]
    public partial class RadioButtons : Microsoft.UI.Xaml.Controls.RadioButtons { }

    [CodeMarkup]
    [ContainerProperty(nameof(Children))]
    public partial class RelativePanel : Microsoft.UI.Xaml.Controls.RelativePanel { }

    [CodeMarkup]
    public partial class SplitView : Microsoft.UI.Xaml.Controls.SplitView { }
}
