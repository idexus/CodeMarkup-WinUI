using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Media.Imaging;
using System.Collections.Generic;
using System;
using Microsoft.UI.Xaml.Data;

namespace ExampleApp
{
    using CodeMarkup.WinUI;
    
    [Bindable]
    public partial class SliderPage : ExamplesBasePage
    {
        public SliderPage()
        {
            Type = typeof(Slider);

            Examples = new()
            {
                new Example
                {
                    new HStack
                    {
                        new Slider(out var slider)
                            .Width(200)
                            .Minimum(1).Maximum(800)
                            .StepFrequency(10),

                        new TextBlock()
                            .Margin(5)
                            .Text(e => e.Path(nameof(slider.Value)).Source(slider))
                    }
                }
                .Title("A Slider with a step frequency 10 and Value binding")
                .SourceText(Sources.SliderWithBinding),

                new Example
                {
                    new Slider()
                        .Orientation(Orientation.Vertical)
                        .Height(100)
                        .Minimum(1).Maximum(800)
                        .StepFrequency(10)
                        .TickFrequency(100)
                }
                .Title("A vertical Slider with a step frequency 10 and tick frequency 100")
                .SourceText(Sources.SliderWithTick),
            };
        }
    }
}

