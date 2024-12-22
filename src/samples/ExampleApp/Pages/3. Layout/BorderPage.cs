using System;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media.Imaging;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI;

namespace ExampleApp
{
    using CodeMarkup.WinUI;
     
    [Bindable]
    public partial class BorderPage : ExamplesBasePage
    {
        public BorderPage()
        {
            Type = typeof(Border);

            Examples = new()
            {
                new Example
                {
                    new Border()
                        .BorderThickness(10)
                        .BorderBrush(Colors.Red)
                        .Background(Colors.Black)
                        .Child(
                            new TextBlock().Text("I'm in border")
                        )
                }
                .Title("A simple Border example")
                .SourceText(Sources.Sample1),
            };
        }
    }
}