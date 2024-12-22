using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml;
using Microsoft.UI;
using Microsoft.UI.Xaml.Data;

namespace ExampleApp
{
    using CodeMarkup.WinUI;

    [Bindable]
    public partial class ContainersPage : ExamplesBasePage
    {
        public ContainersPage()
        {
            Title = "Containers";

            Examples = new()
            {
                new Example
                {
                    new VStack
                    {
                        new TextBlock()
                            .Text("Hello,")
                            .FontSize(40),

                        new TextBlock()
                            .Text("World!"),

                        new Button()
                            .Content("Click me")
                            .Margin(0, 10)
                            .Size(100, 50)
                    }
                }
                .Title("Multi-item VStack container")
                .SourceText(Sources.Sample1),

                new Example
                {
                    new VStack
                    {
                        e => e
                            .Height(200)
                            .Background(Colors.Green)
                            .HorizontalAlignment(HorizontalAlignment.Center)
                            .Padding(20,20),

                        new TextBlock()
                            .Text("Hello, World!")
                            .FontSize(40),

                        new Button()
                            .Content("Click me")
                            .Margin(0, 10)
                            .Size(100, 50)
                    }
                }
                .Title("Setting containers properties")
                .SourceText(Sources.Sample2),

                new Example
                {
                    new Frame
                    {
                        new Button()
                            .Content("Click me")
                            .FontSize(28)
                            .Size(200, 100)
                    }
                }
                .Title("Single-item container (Frame)")
                .SourceText(Sources.Sample3),

                new Example
                {
                    new ScrollViewer()
                        .Height(100)
                        .Content (new VStack
                        {
                            new TextBlock()
                                .Text("Hello,")
                                .FontSize(40),

                            new TextBlock()
                                .Text("World!"),

                            new Button()
                                .Content("Click me")
                                .Margin(0, 10)
                                .Size(100, 50)
                        })                    
                }
                .Title("Single-item container (ScrollViewer - sealed class in WinUI)")
                .SourceText(Sources.Sample4),
            };
        }
    }
}

