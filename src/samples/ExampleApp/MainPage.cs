using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Controls;
using CodeMarkup.WinUI;
namespace ExampleApp
{
    using CodeMarkup.WinUI.Controls;

    internal class MainPage : Page
    {
        Frame frame;

        public MainPage() 
        {
            this.Content = new NavigationView(out var navigation)
            {
                new NavigationViewItem().Content("Home").Icon(new SymbolIcon(Symbol.Home)).OnTapped(e => frame.Content = new HomePage()),
                new NavigationViewItem()
                {
                    e => e.Content("Basic Input").Icon(new SymbolIcon(Symbol.Page)),

                    new NavigationViewItem().Content(nameof(Button)).OnTapped(e => frame.Content = new ButtonPage()),
                    new NavigationViewItem().Content(nameof(CheckBox)).OnTapped(e => frame.Content = new CheckBoxPage()),
                    new NavigationViewItem().Content(nameof(ColorPicker)).OnTapped(e => frame.Content = new ColorPickerPage()),
                    new NavigationViewItem().Content(nameof(ComboBox)).OnTapped(e => frame.Content = new ComboBoxPage()),
                    new NavigationViewItem().Content(nameof(DropDownButton)).OnTapped(e => frame.Content = new DropDownButtonPage()),
                    new NavigationViewItem().Content(nameof(HyperlinkButton)).OnTapped(e => frame.Content = new HyperlinkButtonPage()),
                    new NavigationViewItem().Content(nameof(RadioButton)).OnTapped(e => frame.Content = new RadioButtonPage()),
                    new NavigationViewItem().Content(nameof(RatingControl)).OnTapped(e => frame.Content = new RatingControlPage()),
                    new NavigationViewItem().Content(nameof(RepeatButton)).OnTapped(e => frame.Content = new RepeatButtonPage()),
                    new NavigationViewItem().Content(nameof(Slider)).OnTapped(e => frame.Content = new SliderPage()),
                    new NavigationViewItem().Content(nameof(SplitButton)).OnTapped(e => frame.Content = new SplitButtonPage()),
                    new NavigationViewItem().Content(nameof(ToggleButton)).OnTapped(e => frame.Content = new ToggleButtonPage()),         
                    new NavigationViewItem().Content(nameof(ToggleSplitButton)).OnTapped(e => frame.Content = new ToggleSplitButtonPage()),
                    new NavigationViewItem().Content(nameof(ToggleSwitch)).OnTapped(e => frame.Content = new ToggleSwitchPage()),
                },
                new NavigationViewItem().Content("Collections").Icon(new SymbolIcon(Symbol.List)),
                new NavigationViewItem().Content("Data & Time").Icon(new SymbolIcon(Symbol.CalendarDay)),
                new NavigationViewItem().Content("Navigation").Icon(new SymbolIcon(Symbol.GlobalNavigationButton)),
                new NavigationViewItem().Content("Text").Icon(new SymbolIcon(Symbol.Read))
            }
            .Content(new Frame(out frame) 
            {
                new HomePage()
            });                
        }
    }
}