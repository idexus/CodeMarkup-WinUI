using System.Collections.Generic;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml;

namespace ExampleApp
{
    using CodeMarkup.WinUI.Controls;
    using Microsoft.UI.Xaml.Media;
    using Microsoft.UI;
    using Microsoft.UI.Xaml.Media.Imaging;
    using CodeMarkup.WinUI;
    using CodeMarkup.WinUI.Styling;
    using Windows.UI;

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
                                .FontSize(60)                                
                                .Text("Hello, World!")
                                .TextAlignment(TextAlignment.Center)
                                .Foreground(e => e.ResourceKey("HeaderColor").Source(this)),

                            new TextBlock()
                                .FontSize(20)
                                .Text("Welcome to CodeMarkup WinUI Quick Samples Gallery")
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
