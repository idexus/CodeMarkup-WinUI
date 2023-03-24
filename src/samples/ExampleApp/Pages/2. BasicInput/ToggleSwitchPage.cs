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
    using CodeMarkup.WinUI.Controls;
    
    [Bindable]
    public partial class ToggleSwitchPage : ExamplesBasePage
    {
        public ToggleSwitchPage()
        {
            Type = typeof(ToggleSwitch);

            Examples = new()
            {
                new Example
                {
                    new ToggleSwitch()                   
                }
                .Title("A simple ToggleSwitch")
                .SourceText(Sources.SimpleToggleSwitch),
            };
        }
    }
}

