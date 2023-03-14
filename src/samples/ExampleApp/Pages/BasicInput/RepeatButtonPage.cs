using System;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media.Imaging;
using Microsoft.UI.Xaml.Controls.Primitives;

namespace ExampleApp
{
    using CodeMarkup.WinUI;
    using CodeMarkup.WinUI.Controls;
    using Microsoft.UI.Xaml;

    public partial class RepeatButtonPage : ExamplesBasePage
    {
        private readonly TextBlock textBlock;
        int counter = 0;

        public RepeatButtonPage()
        {
            Title = "RepeatButton";

            Examples = new()
            {
                new Example
                {
                    new HStack
                    {
                        new RepeatButton()
                            .Content("Click me and hold")
                            .OnClick(button =>
                            {
                                counter++;
                                textBlock.Text = $"Counter {counter}";
                            }),

                        new TextBlock()
                            .Assign(out textBlock)
                            .Margin(new Thickness(10))
                    }
                }
                .Title("A RepeatButton with click event handler")
                .SourceText(Sources.SimpleButton),
            };
        }
    }
}

