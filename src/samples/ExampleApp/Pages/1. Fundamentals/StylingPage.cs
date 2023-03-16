using Microsoft.UI.Xaml.Controls;

namespace ExampleApp
{
    using CodeMarkup.WinUI;
    using CodeMarkup.WinUI.Controls;
    using CodeMarkup.WinUI.Styling;
    using Microsoft.UI;
    using Microsoft.UI.Xaml;
    using Windows.UI;

    public partial class StylingPage : ExamplesBasePage
    {
        public StylingPage()
        {
            Title = "Styling";

            var res = new ResourceDictionary() 
            {
                new ThemeValue<Color> { Key = "BackgroundColor", Light = Colors.Cyan, Dark = Colors.Black },

                new Style<Button>(e => e
                    .FontSize(28)
                    .Width(200)
                    .Height(100)                   
                    .HorizontalAlignment(HorizontalAlignment.Center)),

                new Style<TextBlock>(e => e
                    .HorizontalTextAlignment(TextAlignment.Center)
                    .Padding(0,0,0,10)
                    .FontSize(28)),

                new Style<VStack>(e => e
                    .Padding(20))
                {
                    // invoke code on VStack element using Style<T>
                    vstack => 
                    {
                        vstack.Background(e => e.ResourceKey("BackgroundColor").Source(vstack));
                    }
                }
            };

            Examples = new()
            {
                new Example
                {
                    new VStack
                    {
                        new TextBlock().Text("Hello, World!"),
                        new Button().Content("Click me")                            
                    }
                    .InvokeOnElement(e => e.Resources.MergedDictionaries.Add(res))
                }
                .Title("Property Bindings example")
                .SourceText(Sources.Sample1),

            };
        }
    }
}

