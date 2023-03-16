namespace ExampleApp
{
    public partial class FluentMethodsPage
    {
        class Sources
        {
            public const string Sample1 =

$@"new TextBox()
    .Text(""Simple text"")
    .Padding(20)
    .FontSize(20)";

            public const string Sample2 =

$@"new Button()
    .Assign(out var myButton)
    .Content(""Click me"")";

            public const string Sample3 =

$@"new Button(out var button)
    .Content(""Click me"")";

            };
    }
}
