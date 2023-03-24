using Microsoft.UI.Xaml.Data;

namespace ExampleApp
{
    using CodeMarkup.WinUI;
    using CodeMarkup.WinUI.Controls;

    [Bindable]
    public partial class FluentMethodsPage : ExamplesBasePage
    {
        public FluentMethodsPage()
        {
            Title = "Fluent Methods";

            Examples = new()
            {
                new Example
                {
                    new TextBox()
                        .Text("Simple text")
                        .Padding(20)
                        .FontSize(20)
                }
                .Title("An example of using fluent methods to set properties")
                .SourceText(Sources.Sample1),

                new Example
                {
                    new Button()
                        .Assign(out var myButton)
                        .Content("Click me")                        
                }
                .Title("Assigning objects")
                .SourceText(Sources.Sample2),

                new Example
                {
                    new Button(out var button)
                        .Content("Click me")
                }
                .Title("Assigning objects via constructor (only for not sealed classes in WinUI)")
                .SourceText(Sources.Sample3),
            };
        }
    }
}

