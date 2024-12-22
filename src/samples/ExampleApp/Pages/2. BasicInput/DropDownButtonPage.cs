using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media.Imaging;
using System.Collections.Generic;
using Microsoft.UI.Xaml.Data;
using System;
using Microsoft.UI.Xaml.Media;

namespace ExampleApp
{
    using CodeMarkup.WinUI;
    
    [Bindable]
    public partial class DropDownButtonPage : ExamplesBasePage
    {
        public DropDownButtonPage()
        {
            Type = typeof(DropDownButton);

            Examples = new()
            {
                new Example
                {
                    new DropDownButton(e => e.Content("Items"))
                    {
                        new MenuFlyout
                        {
                            new MenuFlyoutItem().Text("Item 1"),
                            new MenuFlyoutItem().Text("Item 2"),
                            new MenuFlyoutItem().Text("Item 3")
                        }
                    }
                }
                .Title("Simple DropDownButton")
                .SourceText(Sources.SimpleButton),

                new Example
                {
                    new DropDownButton()
                    {
                        e => e.Content(new SymbolIcon(Symbol.Mail)),

                        new MenuFlyout
                        {
                            new MenuFlyoutItem()
                                .Text("Send")
                                .Icon(new SymbolIcon(Symbol.Send)),

                            new MenuFlyoutItem()
                                .Text("Reply")
                                .Icon(new SymbolIcon(Symbol.MailReply)),                            
                        }
                    }
                }
                .Title("DropDownButton with icon")
                .SourceText(Sources.DropDownWithIcon),
            };            
        }
    }
}
