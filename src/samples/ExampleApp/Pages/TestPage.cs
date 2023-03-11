using System.Collections.Generic;
using Microsoft.UI.Xaml.Controls;
using CodeMarkup.WinUI;
using Microsoft.UI.Xaml;
using Microsoft.UI;
using Microsoft.UI.Xaml.Media;

namespace ExampleApp
{
    using CodeMarkup.WinUI.Controls;
    using CodeMarkup.WinUI.Styling;

    internal class TestPage : Page
    {
        readonly static ControlTemplate buttonTemplate = new ControlTemplate<Button, Grid>((parent, root) => {

            root.AddVisualStateList(VisualState.CommonStates, new List<VisualState>
            {
                new VisualState(VisualState.Button.PointerOver) {               
                    new Setters<Grid>(root, e => e.Background(new SolidColorBrush(Colors.Red)))
                },

                new VisualState(VisualState.Button.Normal) {
                    new Setters<Grid>(root, e => e.Background(new SolidColorBrush(Colors.Gray)))
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

        readonly ResourceDictionary res = new() {
            new Style<Button>(e => e.Template(buttonTemplate)),
            new Style<TextBlock>
            {
                tb =>
                {
                    if (tb.Text == "Text 3") tb.FontSize(30);
                }
            }
        };

        public TestPage()
        {
            this.Resources = res;
            this.Content = new StackPanel(e => e.HorizontalAlignment(HorizontalAlignment.Right))
            {
                new Button()
                    .FontSize(40)
                    .Content("Hello Button")
                    .Width(300)
                    .Height(300),

                new StackPanel(out var myPanel, e => e.Orientation(Orientation.Horizontal))
                {
                    new TextBlock().Text("Text 1"),
                    new TextBlock().Text("Text 2"),
                    new TextBlock().Text("Text 3"),
                    new TextBlock().Text("Text 4")
                },

                new DropDownButton
                {
                    e => e.Content("Choose"),

                    new MenuFlyout
                    {
                         new MenuFlyoutItem().Text("Item 1"),
                         new MenuFlyoutItem().Text("Item 2"),
                         new MenuFlyoutItem().Text("Item 3"),
                    }
                }
            }
            .AddVisualStateList(new List<VisualState> // must be defined in direct child of Page
            {
                new VisualState()
                {      
                    new Setters<StackPanel>(myPanel, e => e.Orientation(Orientation.Vertical)),
                    new AdaptiveTrigger().MinWindowWidth(720)
                }
            });
        }
    }
}
