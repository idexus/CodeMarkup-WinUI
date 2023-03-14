namespace ExampleApp
{
    public partial class ToggleSplitButtonPage
    {
        class Sources
        {
            public const string SimpleButton =
$@"new ToggleSplitButton(out var toggleSplitButton)
    .Content(new SymbolIcon(Symbol.Add))
    .Flyout(new Flyout
    {{
        new HStack
        {{
            new Button()
                .Content(new SymbolIcon(Symbol.Add))
                .OnClick(button => toggleSplitButton.Content = new SymbolIcon(Symbol.Add)),

            new Button()
                .Content(new SymbolIcon(Symbol.Remove))
                .OnClick(button => toggleSplitButton.Content = new SymbolIcon(Symbol.Remove))
        }}
    }})";

        };
    }
}
