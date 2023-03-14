namespace ExampleApp
{
    public partial class HyperlinkButtonPage
    {
        class Sources
        {
            public const string SimpleHyperlink =
    $@"new HyperlinkButton()
        .Content(""Code Markup WinUI github repository"")
        .NavigateUri (new Uri (""https://github.com/idexus/CodeMarkup.WinUI""))";

            public const string HyperlinkWithEventHandler =
    $@"new HyperlinkButton()
        .Content(""Click me"")
        .OnClick(button =>
        {{
            // do some stuff
        }})";
        };
    }
}
