using System;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media.Imaging;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Data;

namespace ExampleApp
{
    using CodeMarkup.WinUI;
    
    [Bindable]
    public partial class RepeatButtonPage : ExamplesBasePage
    {
        private readonly TextBlock textBlock;
        int counter = 0;

        public RepeatButtonPage()
        {
            Type = typeof(RepeatButton);

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
                            .Margin(10)
                    }
                }
                .Title("A RepeatButton with click event handler")
                .SourceText(Sources.SimpleButton),
            };
        }
    }
}

