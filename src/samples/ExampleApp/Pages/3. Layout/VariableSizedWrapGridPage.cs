using System;
using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media.Imaging;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;

namespace ExampleApp
{
    using CodeMarkup.WinUI;
    
    [Bindable]
    public partial class VariableSizedWrapGridPage : ExamplesBasePage
    {
        public VariableSizedWrapGridPage()
        {
            Type = typeof(VariableSizedWrapGrid);

            Examples = new()
            {
                new Example
                {
                    
                }
                .Title("")
                .SourceText(Sources.Sample1),
            };
        }
    }
}