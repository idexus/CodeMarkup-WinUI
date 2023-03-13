using System.Collections.Generic;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml;

namespace ExampleApp
{
    using CodeMarkup.WinUI.Controls;
    using Microsoft.UI.Xaml.Media.Imaging;

    public partial class HomePage : Page
    {
        int count = 0;

        public HomePage()
        {
            this.VerticalAlignment = VerticalAlignment.Center;

            Content = new ScrollViewer()
                .Content(new VStack(e => e.Margin(new Thickness(40,0, 40, 40)))
                {
                    new Example(e => e.IsExpanded(true))
                    {
                        new StackPanel
                        {
                            new TextBlock()
                                .FontSize(60)
                                .Text("Hello, World!")
                                .TextAlignment(TextAlignment.Center),

                            new TextBlock()
                                .FontSize(20)
                                .Text("Welcome to Code Markup WinUI Gallery")
                                .TextAlignment(TextAlignment.Center),

                            new Button()
                                .Content("Click me")
                                .Margin(new Thickness(0,35,0,15))
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
