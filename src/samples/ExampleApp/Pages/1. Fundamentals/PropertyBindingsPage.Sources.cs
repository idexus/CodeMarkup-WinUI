namespace ExampleApp
{
    public partial class PropertyBindingsPage
    {
        class Sources
        {
            public const string Sample1 =

$@"
new VStack
{{
    new Slider(out var slider)
        .Minimum(1)
        .Maximum(20),

    new TextBlock()
        .Text(e => e.Path(""Value"").Source(slider).Convert<double>(d => $""Slider value: {{d}}""))
        .FontSize(28)
}}";

        };
    }
}
