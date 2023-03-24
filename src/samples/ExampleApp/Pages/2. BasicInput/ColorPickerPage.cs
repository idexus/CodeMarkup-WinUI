using System;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media.Imaging;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Data;

namespace ExampleApp
{
    using CodeMarkup.WinUI;
    using CodeMarkup.WinUI.Controls;
    
    [Bindable]
    public partial class ColorPickerPage : ExamplesBasePage
    {
        public ColorPickerPage()
        {
            Type = typeof(ColorPicker);

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
                .SourceText(Sources.ColorPickerSource),
            };
        }
    }
}

