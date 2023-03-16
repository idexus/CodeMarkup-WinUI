using Microsoft.UI.Xaml.Controls;

namespace ExampleApp
{
    using CodeMarkup.WinUI;
    using CodeMarkup.WinUI.Controls;
    using CodeMarkup.WinUI.Styling;
    using Microsoft.UI;
    using Microsoft.UI.Xaml;
    using Windows.UI;

    public partial class ResourcesPage : ExamplesBasePage
    {
        public ResourcesPage()
        {
            Title = "Resources";

            this.Resources.MergedDictionaries.Add(new()
            {
                { "FontSize", 28 },

                new ThemeValue<Color> { Key = "ButtonColor", Light = Colors.LightPink, Dark = Colors.Red },
                new ThemeValue<Color> { Key = "BackgroundColor", Light = Colors.Cyan, Dark = Colors.Black }
            });

            Examples = new()
            {
                new Example
                {
                    new Grid
                    {
                        new Button()
                            .Content("Click me")
                            .FontSize(e => e.ResourceKey("FontSize").Source(this))
                            .Background(e => e.ResourceKey("ButtonColor").Source(this))
                            .Size(200, 100)
                    }
                    .Padding(20)
                    .Background(e => e.ResourceKey("BackgroundColor").Source(this)),
                }
                .Title("Property Bindings example")
                .SourceText(Sources.Sample1),

            };
        }
    }
}

