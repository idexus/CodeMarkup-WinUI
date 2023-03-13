namespace ExampleApp
{
    public partial class HomePage
    {
        class Sources
        {
            public const string helloWorld =
    $@"new StackPanel
{{
    new TextBlock()
        .FontSize(60)
        .Text(""Hello, World!"")
        .TextAlignment(TextAlignment.Center),

    new TextBlock()
        .FontSize(20)
        .Text(""Welcome to Code Markup WinUI Gallery"")
        .TextAlignment(TextAlignment.Center),

    new Button()
        .Content(""Click me"")
        .Margin(new Thickness(0,40,0,20))
        .FontSize(20)
        .HorizontalAlignment(HorizontalAlignment.Center)
        .OnClick(button =>
        {{
            count++;
            button.Content = $""Clicked {{count}} "";
            button.Content += count == 1 ? ""time"" : ""times"";
        }})
}}";
        }
    }
}
