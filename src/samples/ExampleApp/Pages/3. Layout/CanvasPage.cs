using System;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media.Imaging;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Shapes;
using Microsoft.UI.Xaml.Data;

namespace ExampleApp
{
    using CodeMarkup.WinUI.Controls;
    using Microsoft.UI;
    
    [Bindable]
    public partial class CanvasPage : ExamplesBasePage
    {
        public CanvasPage()
        {
            Type = typeof(Canvas);

            Examples = new()
            {
                new Example
                {
                    new Canvas(e => e.Width(150).Height(150).Background(Colors.Gray))
                    {
                        new Rectangle()
                            .Fill(Colors.Red)
                            .Width(50).Height(50)
                            .CanvasLeft(25).CanvasTop(25).CanvasZIndex(0),

                        new Rectangle()
                            .Fill(Colors.Green)
                            .Width(50).Height(50)
                            .CanvasLeft(50).CanvasTop(50).CanvasZIndex(1),
                        
                        new Rectangle()
                            .Fill(Colors.Blue)
                            .Width(50).Height(50)
                            .CanvasLeft(75).CanvasTop(75).CanvasZIndex(2),
                    }
                }
                .Title("A Canvas example")
                .SourceText(Sources.SampleCode),
            };
        }
    }
}