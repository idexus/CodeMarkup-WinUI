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

new Grid
{{
    new Button()
        .Content(""Click me"")
        .FontSize(e => e.ResourceKey(""FontSize"").Source(this))
        .Background(e => e.ResourceKey(""ButtonColor"").Source(this))
        .Size(100,100)
}}
.Padding(20)
.Background(e => e.ResourceKey(""BackgroundColor"").Source(this)),";

        };
    }
}
