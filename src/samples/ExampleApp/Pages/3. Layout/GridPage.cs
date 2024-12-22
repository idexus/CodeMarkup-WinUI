using System;
using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media.Imaging;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;

namespace ExampleApp
{
    using CodeMarkup.WinUI;
    
    [Bindable]
    public partial class GridPage : ExamplesBasePage
    {
        public GridPage()
        {
            Type = typeof(Grid);

            Examples = new()
            {
                new Example
                {
                    new Grid(out var grid, e => e
                        .Height(400)
                        .RowSpacing(15)
                        .ColumnSpacing(15)
                        .Padding(30)
                        .RowDefinitions(e => e.Star(2).Star(1).Absolute(100).Auto())
                        .ColumnDefinitions(e => e.Star().Star(2)))
                    {
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

                        new Button()
                            .Content("Change background color")
                            .HorizontalAlignment(HorizontalAlignment.Stretch)
                            .Column(0).Row(3)
                            .ColumnSpan(2)
                            .OnClick(e =>
                            {
                                grid.Background(Colors.DarkRed);
                            })
                    }
                }
                .Title("")
                .SourceText(Sources.Sample1),
            };
        }
    }
}