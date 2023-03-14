namespace ExampleApp
{
    public partial class ColorPickerPage
    {
        class Sources
        {
            public const string ColorPickerSource =
$@"new ColorPicker()
    .ColorSpectrumShape(ColorSpectrumShape.Ring)
    .IsMoreButtonVisible(true)
    .IsColorSliderVisible(true)
    .IsColorChannelTextInputVisible(true)
    .IsHexInputVisible(true)
    .IsAlphaEnabled(false)
    .IsAlphaSliderVisible(true)
    .IsAlphaTextInputVisible(true)";

        };
    }
}
