using System;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media.Imaging;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Shapes;
using Microsoft.UI.Xaml.Data;

namespace ExampleApp
{
    using CodeMarkup.WinUI;
    
    [Bindable]
    public partial class ExpanderPage : ExamplesBasePage
    {
        public ExpanderPage()
        {
            Type = typeof(Expander);

            Examples = new()
            {
                new Example
                {
                    new Expander
                    {
                        new VStack
                        {
                            new TextBlock().Text("Line 1"),
                            new TextBlock().Text("Line 2"),
                            new TextBlock().Text("Line 3"),
                        }                        
                    }
                    .IsExpanded(false)
                    .ExpandDirection(ExpandDirection.Down)
                    .Header("Show me")
                }
                .Title("A simple Expander example")
                .SourceText(Sources.SampleCode),
            };
        }
    }
}