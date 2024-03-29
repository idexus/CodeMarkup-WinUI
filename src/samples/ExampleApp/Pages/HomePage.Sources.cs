﻿namespace ExampleApp
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
        .Text(""Code Markup for WinUI"")
        .TextAlignment(TextAlignment.Center),

    new TextBlock()
        .FontSize(20)
        .Text(""Welcome to the Quick Samples Gallery"")
        .TextAlignment(TextAlignment.Center),

    new Button()
        .Content(""Click me"")
        .Margin(0,40,0,20)
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
