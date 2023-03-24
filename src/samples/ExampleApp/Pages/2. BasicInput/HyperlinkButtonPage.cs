using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Media.Imaging;
using System.Collections.Generic;
using System;
using Microsoft.UI.Xaml.Data;

namespace ExampleApp
{
    using CodeMarkup.WinUI.Controls;
    
    [Bindable]
    public partial class HyperlinkButtonPage : ExamplesBasePage
    {
        public HyperlinkButtonPage()
        {
            Type = typeof(HyperlinkButton);

            Examples = new()
            {
                new Example
                {
                    new HyperlinkButton()
                        .Content("Code Markup WinUI github repository")
                        .NavigateUri (new Uri ("https://github.com/idexus/CodeMarkup.WinUI"))
                }
                .Title("A hyperlink button that navigates to a URI")
                .SourceText(Sources.SimpleHyperlink),

                new Example
                {
                    new HyperlinkButton()
                        .Content("Click me")
                        .OnClick(button =>
                        {
                            // do some stuff
                        })
                }
                .Title("A hyper link button with a Click event handler")
                .SourceText(Sources.HyperlinkWithEventHandler),
            };
        }
    }
}

