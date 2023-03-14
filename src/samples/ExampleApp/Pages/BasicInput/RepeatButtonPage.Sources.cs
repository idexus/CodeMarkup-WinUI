namespace ExampleApp
{
    public partial class RepeatButtonPage
    {
        class Sources
        {
            public const string SimpleButton =
$@"new HStack
{{
    new RepeatButton()
        .Content(""Click me and hold"")
        .OnClick(button =>
        {{
            counter++;
            textBlock.Text = $""Counter {{counter}}"";
        }}),

    new TextBlock()
        .Assign(out textBlock)
        .Margin(new Thickness(10))
}}
";

        };
    }
}
