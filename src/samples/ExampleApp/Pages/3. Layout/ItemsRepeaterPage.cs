using System;
using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media.Imaging;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using System.Collections.Generic;
using Microsoft.UI.Xaml.Shapes;


namespace ExampleApp
{
    using CodeMarkup.WinUI;
    using CodeMarkup.WinUI.Controls;
    using CodeMarkup.WinUI.Styling;
    using System.Linq;

    public partial class ItemsRepeaterPage : ExamplesBasePage
    {
        public class PercentData
        {
            public double Percent { get; set; }
        }

        List<PercentData> percentDataList = Enumerable.Range(1, 5).Select(e => new PercentData { Percent = Random.Shared.Next(100) }).ToList();
        readonly static DataTemplate dataTemplate = new DataTemplate<Frame>(root =>
        {
            root.Content = new Border()
                .Background(e => e.ResourceKey("SystemChromeLowColor"))
                .Margin(4)
                .Size(400, 20)
                .Child(
                    new Rectangle()
                        .HorizontalAlignment(HorizontalAlignment.Left)
                        .Fill(e => e.ResourceKey("SystemAccentColor"))
                        .Width(e => e.Path("Percent").Convert<double>(d => d * 4))
                );
        });

        public ItemsRepeaterPage()
        {
            Type = typeof(ItemsRepeater);

            Examples = new()
            {
                new Example
                {
                    new ItemsRepeater()
                        .ItemsSource(percentDataList)
                        .Layout(new StackLayout { Orientation = Orientation.Vertical })
                        .ItemTemplate(dataTemplate)                    
                }
                .Title("Items repeater")
                .SourceText(Sources.Sample1),
            };
        }
    }
}