using System;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media.Imaging;
using Microsoft.UI.Xaml.Controls.Primitives;

namespace ExampleApp
{
    using CodeMarkup.WinUI;
    using CodeMarkup.WinUI.Controls;
    using Microsoft.UI;
    using Microsoft.UI.Xaml;
    using Microsoft.UI.Xaml.Media;

    public partial class ColorPickerPage : ExamplesBasePage
    {
        public ColorPickerPage()
        {
            Title = "ColorPicker";

            Examples = new()
            {
                new Example
                {
                    new ColorPicker()
                        .ColorSpectrumShape(ColorSpectrumShape.Ring)
                        .IsMoreButtonVisible(true)
                        .IsColorSliderVisible(true)
                        .IsColorChannelTextInputVisible(true)
                        .IsHexInputVisible(true)
                        .IsAlphaEnabled(false)
                        .IsAlphaSliderVisible(true)
                        .IsAlphaTextInputVisible(true),
                }
                .Title("A ColorPicker")
                .SourceText(Sources.SimpleButton),
            };
        }
    }
}

