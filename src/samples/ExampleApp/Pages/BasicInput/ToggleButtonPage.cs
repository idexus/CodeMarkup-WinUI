using System;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media.Imaging;
using Microsoft.UI.Xaml.Controls.Primitives;

namespace ExampleApp
{
    using CodeMarkup.WinUI;
    using CodeMarkup.WinUI.Controls;
    using Microsoft.UI.Xaml;

    public partial class ToggleButtonPage : ExamplesBasePage
    {
        public ToggleButtonPage()
        {
            Title = "ToggleButton";

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

