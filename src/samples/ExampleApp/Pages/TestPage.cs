using System.Collections.Generic;
using Microsoft.UI.Xaml.Controls;
using CodeMarkup.WinUI;
using Microsoft.UI.Xaml;
using Microsoft.UI;
using Microsoft.UI.Xaml.Media;

namespace ExampleApp
{
    using CodeMarkup.WinUI.Controls;

    internal class TestPage : Page
    {
        readonly ControlTemplate buttonTemplate = new ControlTemplate<Button, Grid>((parent, root) => {

            root.AddVisualStateList(VisualStates.CommonStates, new List<VisualState>
            {
                new VisualState<Button>(VisualStates.Button.PointerOver) {
                    new Setter().Target(root, nameof(Button.Background)).Value(new SolidColorBrush(Colors.Red)),
                },

                new VisualState<Button>(VisualStates.Button.Normal) {
                    new Setter().Target(root, nameof(Button.Background)).Value(new SolidColorBrush(Colors.Gray)),
                }
            });
            
            root.Add( 
                new Grid(e => e
                    .RowDefinitions(e => e.Auto(count: 2))
                    .VerticalAlignment(VerticalAlignment.Center)
                    .HorizontalAlignment(HorizontalAlignment.Center)) 
                {
                    new TextBlock().Text(e => e.Path(nameof(Button.Content)).Source(parent)).Row(0),
                    new TextBlock().Text("Sub").Row(1)
                });
        });

        public TestPage() 
        {
            this.Content = new StackPanel(e => e.HorizontalAlignment(HorizontalAlignment.Right))
            {
                new Button()
                    .FontSize(40)
                    .Content("Hello Button")
                    .Width(300)
                    .Height(300)
                    .Template(buttonTemplate),

                new StackPanel(out var myPanel, e => e.Orientation(Orientation.Horizontal))
                {
                    new TextBlock().Text("Text 1"),
                    new TextBlock().Text("Text 2"),
                    new TextBlock().Text("Text 3"),
                    new TextBlock().Text("Text 4"),                    
                }
            }
            .AddVisualStateList(new List<VisualState> // must be defined in direct child of Page
            {
                new VisualState<StackPanel>()
                {
                    new Setter().Target(myPanel, nameof(StackPanel.Orientation)).Value(Orientation.Vertical),
                    new AdaptiveTrigger().MinWindowWidth(720)
                }
            });
        }
    }
}
