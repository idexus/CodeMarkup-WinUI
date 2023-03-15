namespace ExampleApp
{
    public partial class ExpanderPage
    {
        class Sources
        {
            public const string SampleCode =
$@"new Expander
{{
    new VStack
    {{
        new TextBlock().Text(""Line 1""),
        new TextBlock().Text(""Line 2""),
        new TextBlock().Text(""Line 3""),
    }}                        
}}
.IsExpanded(false)
.ExpandDirection(ExpandDirection.Down)
.Header(""Show me"")";

        };
    }
}
