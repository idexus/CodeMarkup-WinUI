namespace ExampleApp
{
    public partial class StackPanelPage
    {
        class Sources
        {
            public const string Sample1 =
$@"new StackPanel(e => e.Orientation(Orientation.Horizontal))
{{
    new Rectangle()
        .Fill(Colors.Red)
        .Width(50).Height(50),

    new Rectangle()
        .Fill(Colors.Green)
        .Margin(5)
        .Width(50).Height(50),

    new Rectangle()
        .Fill(Colors.Blue)
        .Width(50).Height(50),
}}

// or

new HStack
{{
    // Children
    ...
}}";

            public const string Sample2 =
$@"new StackPanel(e => e.Orientation(Orientation.Vertical))
{{
    new Rectangle()
        .Fill(Colors.Red)
        .Width(50).Height(50),

    new Rectangle()
        .Fill(Colors.Green)
        .Margin(5)
        .Width(50).Height(50),

    new Rectangle()
        .Fill(Colors.Blue)
        .Width(50).Height(50),
}}

// or

new VStack
{{
    // Children
    ...
}}
";
        };
    }
}
