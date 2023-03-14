namespace ExampleApp
{
    public partial class RadioButtonPage
    {
        class Sources
        {
            public const string RadioButton =
$@"new RadioButtons(e => e.Header(""Options""))
{{
    new RadioButton().Content(""Option 1"").OnChecked(rb => {{ }}),
    new RadioButton().Content(""Option 2"").OnChecked(rb => {{ }}),
    new RadioButton().Content(""Option 3"").OnChecked(rb => {{ }}),
}}";

        };
    }
}
