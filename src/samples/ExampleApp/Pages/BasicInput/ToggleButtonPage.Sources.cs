namespace ExampleApp
{
    public partial class ToggleButtonPage
    {
        class Sources
        {
            public const string SimpleButton =
$@"new ToggleButton()
    .Content(""Toggle me"")
    .OnClick(button =>
    {{
        button.Content = button.IsChecked ?? false ? ""I'm checked"" : ""I'm unchecked"";
    }})";

        };
    }
}
