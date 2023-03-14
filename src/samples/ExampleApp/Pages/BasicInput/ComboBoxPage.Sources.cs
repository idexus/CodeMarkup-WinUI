namespace ExampleApp
{
    public partial class ComboBoxPage
    {
        class Sources
        {
            public const string SimpleComboBox =
$@"new ComboBox
{{
    ""Car"",
    ""Home"",
    ""Door"",
    ""Window""
}}
.PlaceholderText(""Pick a thing"")
.Width(250)
.OnSelectionChanged(combo => combo.PlaceholderText = combo.SelectedValue as string)";

            public const string ComboBoxWithItemSource =
$@"// items source

public List<string> Items {{ get; set; }} = new()
{{
    ""Paul"",
    ""Alice"",
    ""John"",
    ""Max""
}};

// ComboBox in code

new ComboBox()
    .ItemsSource(e => e.Path(nameof(Items)).Source(this))
    .PlaceholderText(""Pick a name"")
    .Width(250)
    .OnSelectionChanged(combo => combo.PlaceholderText = combo.SelectedValue as string)";

        };
    }
}
