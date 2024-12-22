using Windows.UI;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI;

namespace ExampleApp
{
    using CodeMarkup.WinUI;

    [Bindable]
    public partial class HomePage : Page
    {
        int count = 0;

        public HomePage()
        {
            this.Resources = new()
            {
                new ThemeValue<Color> { Key = "HeaderColor", Light = Colors.Navy, Dark = Colors.Aqua }
            };

            this.VerticalAlignment = VerticalAlignment.Center;

            Content = new ScrollViewer()
                .Content(new VStack(e => e.Margin(40,0, 40, 40))
                {
                    new Example(e => e.IsExpanded(true))
                    {
                        new StackPanel
                        {
                            new TextBlock()
                                .FontSize(45)                                
                                .Text("Code Markup for WinUI")
                                .TextAlignment(TextAlignment.Center)
                                .Foreground(e => e.ResourceKey("HeaderColor").Source(this)),

                            new TextBlock()
                                .FontSize(20)
                                .Text("Welcome to the Quick Samples Gallery")
                                .TextAlignment(TextAlignment.Center),

                            new Button()
                                .Content("Click me")
                                .Margin(0,35,0,15)
                                .FontSize(20)
                                .HorizontalAlignment(HorizontalAlignment.Center)
                                .OnClick(button =>
                                {
                                    count++;
                                    button.Content = $"Clicked {count} ";
                                    button.Content += count == 1 ? "time" : "times";
                                })
                        }
                    }
                    .SourceText(Sources.helloWorld)
                });
        }
    }
}
