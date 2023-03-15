using System;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media.Imaging;
using Microsoft.UI.Xaml.Controls.Primitives;

namespace ExampleApp
{
    using CodeMarkup.WinUI;
    using CodeMarkup.WinUI.Controls;
    using Microsoft.UI;
    using Microsoft.UI.Xaml;
    using Microsoft.UI.Xaml.Media;

    public partial class SplitButtonPage : ExamplesBasePage
    {
        public SplitButtonPage()
        {
            Type = typeof(SplitButton);

            Examples = new()
            {
                new Example
                {
                    new SplitButton()
                        .Content("Choose color")
                        .Flyout(new Flyout
                        {
                            new VStack
                            {
                                new Button().Width(70).Height(50).Background(Colors.Red),
                                new Button().Width(70).Height(50).Background(Colors.Green),
                                new Button().Width(70).Height(50).Background(Colors.Blue),
                            }
                        }),
                }
                .Title("A SplitButton with VStack in flyout")
                .SourceText(Sources.SimpleButton),
            };
        }
    }
}

