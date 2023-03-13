using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Media.Imaging;
using System.Collections.Generic;
using System;

namespace ExampleApp
{
    using CodeMarkup.WinUI.Controls;

    public partial class ButtonPage : ExamplesBasePage
    {
        public ButtonPage()
        {
            Title = "Button";

            Examples = new()
            {
                new Example
                {
                    new Button()
                        .Content("Click me")
                        .OnClick(button =>
                        {
                            button.Content = "Clicked";
                        })
                }
                .Title("A Button with click event handler")
                .SourceText(Sources.SimpleButton),

                new Example
                {
                    new Button
                    {
                        new Image()
                            .Width(50)
                            .Source(new BitmapImage(new Uri("ms-appx:///Assets/StoreLogo.png")))
                    }
                    .OnClick(button =>
                    {
                        // do some stuff
                    })
                }
                .Title("A Button with image content")
                .SourceText(Sources.WithImageButton),
            };
        }
    }
}

