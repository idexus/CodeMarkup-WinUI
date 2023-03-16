namespace ExampleApp
{
    public partial class ButtonPage
    {
        class Sources
        {
            public const string SimpleButton =
$@"new Button()
    .Content(""Click me"")
    .OnClick(button =>
    {{
        button.Content = ""Clicked"";
    }})";

            public const string WithImageButton =
    $@"new Button
{{
    new Image()
        .Width(50)
        .Source(new BitmapImage(new Uri(""ms-appx:///Assets/StoreLogo.png"")))
                            
}}
.OnClick(button =>
{{
    // do some stuff
}})";
        };
    }
}
