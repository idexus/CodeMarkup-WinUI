using System;
using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media.Imaging;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Shapes;

namespace ExampleApp
{
    using CodeMarkup.WinUI;
    using CodeMarkup.WinUI.Controls;

    public partial class StackPanelPage : ExamplesBasePage
    {
        public StackPanelPage()
        {
            Type = typeof(StackPanel);

            Examples = new()
            {

                new Example
                {
                    new StackPanel(e => e.Orientation(Orientation.Horizontal))
                    {
                        new Rectangle()
                            .Fill(Colors.Red)
                            .Width(50).Height(50),

                        new Rectangle()
                            .Fill(Colors.Green)
                            .Margin(5)
                            .Width(50).Height(50),

                        new Rectangle()
                            .Fill(Colors.Blue)
                            .Width(50).Height(50),
                    }
                }
                .Title("Simple horizontal stack panel (HStack)")
                .SourceText(Sources.Sample1),

                new Example
                {
                    new StackPanel(e => e.Orientation(Orientation.Vertical))
                    {
                        new Rectangle()
                            .Fill(Colors.Red)
                            .Width(50).Height(50),

                        new Rectangle()
                            .Fill(Colors.Green)
                            .Margin(5)
                            .Width(50).Height(50),

                        new Rectangle()
                            .Fill(Colors.Blue)
                            .Width(50).Height(50),
                    }
                }
                .Title("Simple vertical stack panel (VStack)")
                .SourceText(Sources.Sample2),
            };
        }
    }
}