using Microsoft.UI.Xaml.Controls;

namespace ExampleApp
{
    public partial class ItemsRepeaterPage
    {
        class Sources
        {
            public const string Sample1 =
$@"new ItemsRepeater()
    .ItemsSource(percentDataList)
    .Layout(new StackLayout {{Orientation = Orientation.Vertical}})
    .ItemTemplate(dataTemplate) 

// data template declaration (class static property)

readonly static DataTemplate dataTemplate = new DataTemplate<Frame>(root =>
{{
    root.Content = new Border()
        .Background(e => e.ResourceKey(""SystemChromeLowColor"").Source(root))
        .Margin(4)
        .Size(400, 20)
        .Child(
            new Rectangle()
                .HorizontalAlignment(HorizontalAlignment.Left)
                .Fill(e => e.ResourceKey(""SystemAccentColor"").Source(root))
                .Width(e => e.Path(""Percent"").Convert<double>(d => d * 4))
        );
}});";

        };
    }
}
