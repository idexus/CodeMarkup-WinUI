namespace ExampleApp
{
    public partial class ContainersPage
    {
        class Sources
        {
            public const string Sample1 =

$@"new VStack
{{
    new TextBlock()
        .Text(""Hello,"")
        .FontSize(40),

    new TextBlock()
        .Text(""World!""),

    new Button()
        .Content(""Click me"")
        .Margin(0, 10)
        .Size(100, 50)
}}";

            public const string Sample2 =

$@"
new VStack(e => e
    .Height(200)
    .Background(Colors.Green)
    .HorizontalAlignment(HorizontalAlignment.Center)
    .Padding(20,20))
{{
    new TextBlock()
        .Text(""Hello, World!"")
        .FontSize(40),

    new Button()
        .Content(""Click me"")
        .Margin(0, 10)
        .Size(100, 50)
}}

// or

new VStack
{{
    // setting properties

    e => e
        .Height(200)
        .Background(Colors.Green)
        .HorizontalAlignment(HorizontalAlignment.Center)
        .Padding(20,20),

    // container content here

    new TextBlock()
        .Text(""Hello, World!"")
        .FontSize(40),

    new Button()
        .Content(""Click me"")
        .Margin(0, 10)
        .Size(100, 50)
}}        

// or 

new VStack
{{
    new TextBlock()
        .Text(""Hello, World!"")
        .FontSize(40),

    new Button()
        .Content(""Click me"")
        .Margin(0, 10)
        .Size(100, 50)
}}        
.Height(200)
.Background(Colors.Green)
.HorizontalAlignment(HorizontalAlignment.Center)
.Padding(20,20)
";

            public const string Sample3 =

$@"new Frame
{{
    new Button()
        .Content(""Click me"")
        .FontSize(28)
        .Size(200, 100)
}}";

            public const string Sample4 =

$@"new ScrollViewer()
    .Height(100)
    .Content (new VStack
    {{
        new TextBlock()
            .Text(""Hello,"")
            .FontSize(40),

        new TextBlock()
            .Text(""World!""),

        new Button()
            .Content(""Click me"")
            .Margin(0, 10)
            .Size(100, 50)
        }}
    }})";

            };
    }
}
