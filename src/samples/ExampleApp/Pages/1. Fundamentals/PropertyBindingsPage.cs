using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Data;

namespace ExampleApp
{
    using CodeMarkup.WinUI;

    [Bindable]
    public partial class PropertyBindingsPage : ExamplesBasePage
    {
        public PropertyBindingsPage()
        {
            Title = "Property Bindings";

            Examples = new()
            {
                new Example
                {
                    new VStack
                    {
                        new Slider(out var slider)
                            .Minimum(1)
                            .Maximum(20),

                        new TextBlock()
                            .Text(e => e.Path("Value").Source(slider).Convert<double>(d => $"Slider value: {d}"))
                            .FontSize(28)
                    }
                }
                .Title("Property Bindings example")
                .SourceText(Sources.Sample1),

            };
        }
    }
}

