using Microsoft.UI.Xaml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.UI.Xaml.Controls;

namespace ExampleApp
{
    using CodeOnly.WinUI.Core;

    internal class BlankWindow : Window
    {
        public string text { get; set; } = "DZIALA";

        public BlankWindow()
        {
            Content = new StackPanel()
                .HorizontalAlignment(HorizontalAlignment.Center)
                .VerticalAlignment(VerticalAlignment.Center)
                .Children(new List<UIElement>()
                {
                    new Button()
                        .Content("Standard Button")
                        .Width(300)
                        .Height(300)
                        .OnClick(button =>
                        {
                            button.Content = "Clicked";
                        }),

                    new TextBlock()
                        .Text(e => e.Path("text").Source(this))
                });            
        }
    }
}
