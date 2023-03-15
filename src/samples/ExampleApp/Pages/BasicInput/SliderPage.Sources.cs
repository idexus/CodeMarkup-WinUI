namespace ExampleApp
{
    public partial class SliderPage
    {
        class Sources
        {
            public const string SliderWithBinding =
    $@"new HStack
{{
    new Slider(out var slider)
        .Width(200)
        .Minimum(1).Maximum(800)
        .StepFrequency(10),

    new TextBlock()
        .Margin(5)
        .Text(e => e.Path(nameof(slider.Value)).Source(slider))
}}";

            public const string SliderWithTick =
    $@"new Slider()
    .Orientation(Orientation.Vertical)
    .Height(100)
    .Minimum(1).Maximum(800)
    .StepFrequency(10)
    .TickFrequency(100)";
        };
    }
}
