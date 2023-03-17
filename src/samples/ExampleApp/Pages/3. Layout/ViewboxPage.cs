using System;
using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media.Imaging;
using Microsoft.UI.Xaml.Controls.Primitives;

namespace ExampleApp
{
    using CodeMarkup.WinUI;
    using CodeMarkup.WinUI.Controls;

    public partial class ViewboxPage : ExamplesBasePage
    {
        public ViewboxPage()
        {
            Type = typeof(Viewbox);

            Examples = new()
            {
                new Example
                {
                    new Viewbox()
                        .Size(200, 200)
                        .Stretch(Stretch.Uniform)
                        .StretchDirection(StretchDirection.Both)
                        .Child(new Grid
                        {
                            e => e
                                .Size(500, 500)
                                .RowSpacing(15)
                                .ColumnSpacing(15)
                                .RowDefinitions(e => e.Star(2).Star().Star())
                                .ColumnDefinitions(e => e.Star().Star(2)),

                            new Frame().Background(Colors.Red),
                            new TextBlock().Text("Column 0, Row 0"),

                            new Frame().Background(Colors.Blue).Column(1).Row(0),
                            new TextBlock().Text("Column 1, Row 0").Column(1).Row(0),

                            new Frame().Background(Colors.Teal).Column(0).Row(1),
                            new TextBlock().Text("Column 0, Row 1").Column(0).Row(1),

                            new Frame().Background(Colors.Purple).Column(1).Row(1),
                            new TextBlock().Text("Column 1, Row 1").Column(1).Row(1),

                            new Frame().Background(Colors.Red).Column(0).Row(2).GridSpan(column: 2),
                            new TextBlock().Text("Column 0, Row 2, Span 2 columns").Column(0).Row(2).GridSpan(column: 2),
                        })
                }
                .Title("Viewbox example")
                .SourceText(Sources.Sample1),
            };
        }
    }
}