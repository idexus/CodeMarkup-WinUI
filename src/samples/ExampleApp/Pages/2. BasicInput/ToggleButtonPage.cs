

namespace ExampleApp
{
    using CodeMarkup.WinUI.Controls;
    using Microsoft.UI.Xaml.Data;

    [Bindable]
    public partial class ToggleButtonPage : ExamplesBasePage
    {
        public ToggleButtonPage()
        {
            Type = typeof(ToggleButton);

            Examples = new()
            {
                new Example
                {
                    new ToggleButton()
                        .Content("Toggle me")
                        .OnClick(button =>
                        {
                            button.Content = button.IsChecked ?? false ? "I'm checked" : "I'm unchecked";
                        }),
                }
                .Title("A ToggleButton with click event handler")
                .SourceText(Sources.SimpleButton),
            };
        }
    }
}

