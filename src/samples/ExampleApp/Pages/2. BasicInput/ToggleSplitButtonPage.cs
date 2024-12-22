using System;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media.Imaging;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Data;

namespace ExampleApp
{
    using CodeMarkup.WinUI;
    
    [Bindable]
    public partial class ToggleSplitButtonPage : ExamplesBasePage
    {
        public ToggleSplitButtonPage()
        {
            Type = typeof(ToggleSplitButton);

            Examples = new()
            {
                new Example
                {
                    new ToggleSplitButton(out var toggleSplitButton)
                        .Content(new SymbolIcon(Symbol.Add))
                        .Flyout(new Flyout
                        {
                            new HStack
                            {
                                new Button()
                                    .Content(new SymbolIcon(Symbol.Add))
                                    .OnClick(button => toggleSplitButton.Content = new SymbolIcon(Symbol.Add)),

                                new Button()
                                    .Content(new SymbolIcon(Symbol.Remove))
                                    .OnClick(button => toggleSplitButton.Content = new SymbolIcon(Symbol.Remove))
                            }
                        })
                }
                .Title("A ToggleSplitButton with 2 Buttons in flyout")
                .SourceText(Sources.SimpleButton),
            };
        }
    }
}

