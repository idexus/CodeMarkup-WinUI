namespace ExampleApp
{
    public partial class ResourcesPage
    {
        class Sources
        {
            public const string Sample1 =

$@"this.Resources.MergedDictionaries.Add(new()
{{
    {{ ""FontSize"", 28 }},

    new ThemeValue<Color> {{ Key = ""ButtonColor"", Light = Colors.LightPink, Dark = Colors.Red }},
    new ThemeValue<Color> {{ Key = ""BackgroundColor"", Light = Colors.Cyan, Dark = Colors.Black }}
}});

// Further in the code

new HStack
{{
    new Button()
        .Content(""Click me"")
        .FontSize(e => e.ResourceKey(""FontSize"").Source(this))
        .Background(e => e.ResourceKey(""ButtonColor"").Source(this))
        .Size(200, 60),

    new Frame()
        .Size(200, 60)
        .Margin(10, 0)
        .Background(e => e.ResourceKey(""BackgroundColor"").Source(this))
}}
.Padding(20)
.Background(e => e.ResourceKey(""SystemChromeLowColor"")),  // WinUI resources";

        };
    }
}
