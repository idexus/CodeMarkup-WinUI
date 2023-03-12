using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml;
using CodeMarkup.WinUI;
using Microsoft.UI;
using Microsoft.UI.Xaml.Media;

namespace ExampleApp
{
    using CodeMarkup.WinUI.Controls;
    using ColorCode;
    using ColorCode.Common;

    public class ButtonPage : Page
    {
        public ButtonPage()
        {
            var block =
$@"
new Button().Content(""Click me"")
new Button().Content(""Click me"")
new Button().Content(""Click me"")
";
            var formatter = new RichTextBlockFormatter(ElementTheme.Dark);
            var sampleCodeRTB = new RichTextBlock().FontFamily(new FontFamily("Consolas"));
            formatter.FormatRichTextBlock(block, Languages.CSharp, sampleCodeRTB);

            Content = new VStack(e => e.Margin(new Thickness(40)))
            {
                new TextBlock().Text("Button").FontSize(60).Margin(new Thickness(0,0,0,20)),

                new TextBlock().Text("A simple Button with text content").FontSize(20).Margin(new Thickness(0,10,0,10)),
                new Grid(e => e.RowDefinitions(e => e.Auto(count: 2)).Padding(new Thickness(10)))
                {
                    new Grid(e => e.Margin(new Thickness(1,0,1,0)).Padding(new Thickness(20)).Background(new SolidColorBrush(Colors.MidnightBlue)))
                    {
                        new Button().Content("Click me")
                    },
                    new Expander()
                        .Row(1)
                        .IsExpanded(false)
                        .HorizontalAlignment(HorizontalAlignment.Stretch)
                        .ExpandDirection(ExpandDirection.Down)
                        .Header("Source code")
                        .Content(new Grid(e => e.Padding(new Thickness(10,0,10,0)).Width(int.MaxValue))
                        {
                            sampleCodeRTB
                        }),
                }
            };
        }
    }
}
