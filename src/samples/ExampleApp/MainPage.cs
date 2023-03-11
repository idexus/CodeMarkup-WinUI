using System.Collections.Generic;
using Microsoft.UI.Xaml.Controls;
using CodeMarkup.WinUI;
using Microsoft.UI.Xaml;
using Microsoft.UI;
using Microsoft.UI.Xaml.Media;

namespace ExampleApp
{
    using CodeMarkup.WinUI.Controls;

    internal class MainPage : Page
    {
        public MainPage() 
        {
            this.Content = new NavigationView
            {
                new NavigationViewItem().Content("Home").Icon(new SymbolIcon(Symbol.Home)),
                new NavigationViewItem()
                {
                    e => e.Content("Basic Input").Icon(new SymbolIcon(Symbol.Page)),

                    new NavigationViewItem().Content("Button"),
                    new NavigationViewItem().Content("DropDownButton"),
                    new NavigationViewItem().Content("HyperlinkButton"),
                    new NavigationViewItem().Content("RepeatButton"),
                    new NavigationViewItem().Content("ToggleButton"),
                    new NavigationViewItem().Content("CheckBox"),
                    new NavigationViewItem().Content("ColorPicker"),
                    new NavigationViewItem().Content("ComboBox"),
                    new NavigationViewItem().Content("RadioButton"),
                    new NavigationViewItem().Content("RatingControl"),
                    new NavigationViewItem().Content("Slider"),
                    new NavigationViewItem().Content("ToggleSwitch"),
                },
                new NavigationViewItem().Content("Collections").Icon(new SymbolIcon(Symbol.List)),
                new NavigationViewItem().Content("Data & Time").Icon(new SymbolIcon(Symbol.CalendarDay)),
                new NavigationViewItem().Content("Navigation").Icon(new SymbolIcon(Symbol.GlobalNavigationButton)),
                new NavigationViewItem().Content("Text").Icon(new SymbolIcon(Symbol.Read))
            }
            .Content(new Frame 
            {
                new TestPage()
            });                
        }
    }
}