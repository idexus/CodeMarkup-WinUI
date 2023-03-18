namespace ExampleApp
{
    public partial class PasswordBoxPage
    {
        class Sources
        {
            public const string Sample1 =
$@"new PasswordBox().Width(300)";

            public const string Sample2 =
$@"
new HStack(e => e.HorizontalAlignment(HorizontalAlignment.Center))
{{
    new PasswordBox()
        .Assign(out var passBox)
        .Width(300)
        .PasswordChar(""#""),

    new CheckBox()
        .Margin(20, 0)
        .Content(""Show password"")                            
        .InvokeOnElement(checkBox =>
        {{
            passBox.PasswordRevealMode(e => e
                .Path(""IsChecked"").Source(checkBox)
                .Convert<bool>(isChecked => isChecked ? PasswordRevealMode.Visible : PasswordRevealMode.Hidden));
        }})
}}";
        };
    }
}
