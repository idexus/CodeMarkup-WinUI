using System.Collections.Generic;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml;
using Microsoft.UI;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Data;

namespace ExampleApp
{
    using CodeMarkup.WinUI;
    using CodeMarkup.WinUI.Controls;
    using CodeMarkup.WinUI.Styling;


    public class TestPage : Page
    {
        readonly static ControlTemplate buttonTemplate = new ControlTemplate<Grid>((root, parent) =>
        {
            root.AddVisualStateGroup(VisualState.CommonStates, new List<VisualState> {
                new VisualState(VisualState.Button.PointerOver) {
                    new Setters<Grid>(root, e => e.Background(Colors.Red)),
                },

                new VisualState(VisualState.Button.Normal) {
                    new Setters<Grid>(root, e => e.Background(Colors.Gray))
                }
            });

            root.Add(
                new Grid(e => e
                    .RowDefinitions(e => e.Auto(count: 2))
                    .VerticalAlignment(VerticalAlignment.Center)
                    .HorizontalAlignment(HorizontalAlignment.Center))
                {
                    new TextBlock().Text(e => e.Path(nameof(Button.Content)).Source(parent)).Row(0),
                    new TextBlock().Text("Sub title").Row(1).FontSize(20)
                });
        });

        readonly ResourceDictionary res = new() {
            new Style<Button>(e => e.Template(buttonTemplate)),
            new Style<TextBlock>
            {
                // run code block with style on element
                tb =>
                {
                    if (tb.Text == "Text 3") tb.FontSize(20); 
                }
            }
        }; 

        public TestPage()
        {
            this.Resources = res;
            
            this.HorizontalAlignment = HorizontalAlignment.Center;
            this.VerticalAlignment = VerticalAlignment.Center;

            this.Content = new StackPanel(e => e.HorizontalAlignment(HorizontalAlignment.Right))
            {
                new Button()
                    .FontSize(40)
                    .Content("Hello, World, it's my App!") 
                    .Width(500)
                    .Height(100),

                new StackPanel(out var myPanel, e => e.Orientation(Orientation.Horizontal))
                {
                    new TextBlock().Text("Text 1"),
                    new TextBlock().Text("Text 2"),
                    new TextBlock().Text("Text 3"),
                    new TextBlock().Text("Text 4")
                },

                new DropDownButton(out var dropDown)
                {
                    e => e.Content("Choose"),

                    new MenuFlyout
                    {
                         new MenuFlyoutItem().Text("Item 1").OnClick(e => {dropDown.Content = "Selected 1"; }),
                         new MenuFlyoutItem().Text("Item 2").OnClick(e => {dropDown.Content = "Selected 2"; }),
                         new MenuFlyoutItem().Text("Item 3").OnClick(e => {dropDown.Content = "Selected 3"; }),
                    }
                }
            }
            .AddVisualStateGroup(new List<VisualState> // must be defined in direct child of Page
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
