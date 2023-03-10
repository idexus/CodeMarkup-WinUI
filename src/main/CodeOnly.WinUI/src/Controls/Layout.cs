using CodeOnly.WinUI;


namespace CodeOnly.WinUI.Controls
{
    [SharpObject]
    public partial class Grid : Microsoft.UI.Xaml.Controls.Grid { }

    [SharpObject]
    public partial class StackPanel : Microsoft.UI.Xaml.Controls.StackPanel { }

    [SharpObject]
    public partial class VStack : Microsoft.UI.Xaml.Controls.StackPanel 
    { 
        public VStack() { Orientation = Microsoft.UI.Xaml.Controls.Orientation.Vertical; }
    }

    [SharpObject]
    public partial class HStack : Microsoft.UI.Xaml.Controls.StackPanel
    {
        public HStack() { Orientation = Microsoft.UI.Xaml.Controls.Orientation.Horizontal; }
    }
}
