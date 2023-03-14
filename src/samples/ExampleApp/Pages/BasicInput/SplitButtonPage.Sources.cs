namespace ExampleApp
{
    public partial class SplitButtonPage
    {
        class Sources
        {
            public const string SimpleButton =
$@"new SplitButton()
    .Content(""Choose color"")
    .Flyout(new Flyout
    {{
        new VStack
        {{
            new Button().Width(70).Height(50).Background(new SolidColorBrush(Colors.Red)),
            new Button().Width(70).Height(50).Background(new SolidColorBrush(Colors.Green)),
            new Button().Width(70).Height(50).Background(new SolidColorBrush(Colors.Blue)),
        }}
    }})";

        };
    }
}
