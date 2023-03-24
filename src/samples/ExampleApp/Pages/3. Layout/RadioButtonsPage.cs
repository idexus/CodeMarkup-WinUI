using System;
using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media.Imaging;
using Microsoft.UI.Xaml.Controls.Primitives;
using Windows.UI;
using Microsoft.UI.Xaml.Data;

namespace ExampleApp
{
    using CodeMarkup.WinUI;
    using CodeMarkup.WinUI.Controls;
    
    [Bindable]
    public partial class RadioButtonsPage : ExamplesBasePage
    {
        public RadioButtonsPage()
        {
            Type = typeof(RadioButtons);

            Examples = new()
            {
                new Example
                {
                    new RadioButtons
                    {
                        "Default",
                        "Red",
                        "Green",
                        "Blue",                        
                    }
                    .Header("Radio Buttons")
                    .SelectedIndex(0)
                    .MaxColumns(4)
                    .OnSelectionChanged(rb =>
                    {
                        this.Background(rb.SelectedIndex switch
                        {
                            1 => Colors.Red,
                            2 => Colors.Green,
                            3 => Colors.Blue,
                            _ => Colors.Transparent,
                        });
                    })
                }
                .Title("")
                .SourceText(Sources.Sample1),
            };
        }
    }
}