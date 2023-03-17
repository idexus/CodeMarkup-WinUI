namespace ExampleApp
{
    public partial class RadioButtonsPage
    {
        class Sources
        {
            public const string Sample1 =
$@"new RadioButtons
{{
    ""Default"",
    ""Red"",
    ""Green"",
    ""Blue"",                        
}}
.Header(""Radio Buttons"")
.SelectedIndex(0)
.MaxColumns(4)
.OnSelectionChanged(rb =>
{{
    this.Background(rb.SelectedIndex switch
    {{
        1 => Colors.Red,
        2 => Colors.Green,
        3 => Colors.Blue,
        _ => Colors.Transparent,
    }});
}})";

        };
    }
}
