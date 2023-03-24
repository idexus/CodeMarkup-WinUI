using Microsoft.UI.Xaml.Controls;
using Microsoft.UI;
using Microsoft.UI.Xaml;
using Windows.UI;
using Microsoft.UI.Xaml.Data;

namespace ExampleApp
{
    using CodeMarkup.WinUI;
    using CodeMarkup.WinUI.Controls;
    using CodeMarkup.WinUI.Styling;

    [Bindable]
    public partial class ResourcesPage : ExamplesBasePage
    {
        public ResourcesPage()
        {
            Title = "Resources";

            this.Resources.MergedDictionaries.Add(new()
            {
                { "FontSize", 28 },

                new ThemeValue<Color> { Key = "ButtonColor", Light = Colors.LightPink, Dark = Colors.Red },
                new ThemeValue<Color> { Key = "BackgroundColor", Light = Colors.LightCoral, Dark = Colors.Blue }
            });

            Examples = new()
            {
                new Example
                {
                    new HStack
                    {
                        new Button()
                            .Content("Click me")
                            .FontSize(e => e.ResourceKey("FontSize").Source(this))
                            .Background(e => e.ResourceKey("ButtonColor").Source(this))
                            .Size(200, 60),

                        new Frame()
                            .Size(200, 60)
                            .Margin(10, 0)
                            .Background(e => e.ResourceKey("BackgroundColor").Source(this))
                    }
                    .Padding(20)
                    .Background(e => e.ResourceKey("SystemChromeLowColor")),  // WinUI resources
                }
                .Title("Property Bindings example")
                .SourceText(Sources.Sample1),

            };
        }
    }
}
