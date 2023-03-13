namespace ExampleApp
{
    public partial class DropDownButtonPage
    {
        class Sources
        {
            public const string SimpleButton =
$@"new DropDownButton(e => e.Content(""Items""))
{{
    new MenuFlyout
    {{
        new MenuFlyoutItem().Text(""Item 1""),
        new MenuFlyoutItem().Text(""Item 2""),
        new MenuFlyoutItem().Text(""Item 3"")
    }}
}}";

            public const string DropDownWithIcon =
                $@"
new DropDownButton()
{{
    e => e.Content(new SymbolIcon(Symbol.Mail)),

    new MenuFlyout
    {{
        new MenuFlyoutItem()
            .Text(""Send"")
            .Icon(new SymbolIcon(Symbol.Send)),

        new MenuFlyoutItem()
            .Text(""Reply"")
            .Icon(new SymbolIcon(Symbol.MailReply)),
    }}
}}
";
        }
    }
}
