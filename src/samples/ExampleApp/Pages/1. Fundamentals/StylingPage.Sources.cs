namespace ExampleApp
{
    public partial class StylingPage
    {
        class Sources
        {
            public const string Sample1 =

$@"this.Resources.MergedDictionaries.Add(new() 
{{
    new ThemeValue<Color> {{ Key = ""BackgroundColor"", Light = Colors.Cyan, Dark = Colors.Black }},

    new Style<Button>(e => e
        .FontSize(28)
        .Width(200)
        .Height(100)
        .Padding(10)
        .HorizontalAlignment(HorizontalAlignment.Center)),

    new Style<TextBlock>(e => e
        .HorizontalTextAlignment(TextAlignment.Center)
        .FontSize(28)),

    new Style<VStack>(e => e
        .Padding(20))
    {{
        // invoke code on VStack element using Style<T>
        vstack => 
        {{
            vstack.Background(e => e.ResourceKey(""BackgroundColor"").Source(this));
        }}
    }}
}});

// Further in the code

new VStack
{{
    new TextBlock().Text(""Test""),
    new Button().Content(""Click me"")                            
}}
";

        };
    }
}
