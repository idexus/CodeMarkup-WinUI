using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml;
using Microsoft.UI;
using Windows.UI;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Controls;

namespace ExampleApp
{
    using CodeMarkup.WinUI;

    internal class MainPage : Page
    {
        public static Frame frame;

        public MainPage() 
        {
            this.Resources.MergedDictionaries.Add(new()
            {
                new ThemeValue<Color> { Key = "BackgroundColor", Dark = Colors.Black, Light = Colors.LightBlue }
            });

            this.Content = new NavigationView
            {
                new NavigationViewItem().Content("Home").Icon(new SymbolIcon(Symbol.Home)).OnTapped(e => frame.Navigate(typeof(HomePage))),
                new NavigationViewItem
                {
                    e => e.Content("Fundamentals").Icon(new FontIcon { Glyph = "\uE71D" }),

                    new NavigationViewItem().Content("Fluent methods").OnTapped(e => frame.Navigate(typeof(FluentMethodsPage))),
                    new NavigationViewItem().Content("Containers").OnTapped(e => frame.Navigate(typeof(ContainersPage))),
                    new NavigationViewItem().Content("Property Bindings").OnTapped(e => frame.Navigate(typeof(PropertyBindingsPage))),
                    new NavigationViewItem().Content("Resources").OnTapped(e => frame.Navigate(typeof(ResourcesPage))),
                    new NavigationViewItem().Content("Styling").OnTapped(e => frame.Navigate(typeof(StylingPage))),
                },
                new NavigationViewItem
                {
                    e => e.Content("Basic Input").Icon(new FontIcon { Glyph = "\uF16C" }),

                    new NavigationViewItem().Content(nameof(Button)).OnTapped(e => frame.Navigate(typeof(ButtonPage))),
                    new NavigationViewItem().Content(nameof(CheckBox)).OnTapped(e => frame.Navigate(typeof(CheckBoxPage))),
                    new NavigationViewItem().Content(nameof(ColorPicker)).OnTapped(e => frame.Navigate(typeof(ColorPickerPage))),
                    new NavigationViewItem().Content(nameof(ComboBox)).OnTapped(e => frame.Navigate(typeof(ComboBoxPage))),
                    new NavigationViewItem().Content(nameof(DropDownButton)).OnTapped(e => frame.Navigate(typeof(DropDownButtonPage))),
                    new NavigationViewItem().Content(nameof(HyperlinkButton)).OnTapped(e => frame.Navigate(typeof(HyperlinkButtonPage))),
                    new NavigationViewItem().Content(nameof(RadioButton)).OnTapped(e => frame.Navigate(typeof(RadioButtonPage))),
                    new NavigationViewItem().Content(nameof(RatingControl)).OnTapped(e => frame.Navigate(typeof(RatingControlPage))),
                    new NavigationViewItem().Content(nameof(RepeatButton)).OnTapped(e => frame.Navigate(typeof(RepeatButtonPage))),
                    new NavigationViewItem().Content(nameof(Slider)).OnTapped(e => frame.Navigate(typeof(SliderPage))),
                    new NavigationViewItem().Content(nameof(SplitButton)).OnTapped(e => frame.Navigate(typeof(SplitButtonPage))),
                    new NavigationViewItem().Content(nameof(ToggleButton)).OnTapped(e => frame.Navigate(typeof(ToggleButtonPage))),         
                    new NavigationViewItem().Content(nameof(ToggleSplitButton)).OnTapped(e => frame.Navigate(typeof(ToggleSplitButtonPage))),
                    new NavigationViewItem().Content(nameof(ToggleSwitch)).OnTapped(e => frame.Navigate(typeof(ToggleSwitchPage))),
                },
                new NavigationViewItem
                {
                    e => e.Content("Layout").Icon(new SymbolIcon(Symbol.ViewAll)),

                    new NavigationViewItem().Content(nameof(Border)).OnTapped(e => frame.Navigate(typeof(BorderPage))),
                    new NavigationViewItem().Content(nameof(Canvas)).OnTapped(e => frame.Navigate(typeof(CanvasPage))),
                    new NavigationViewItem().Content(nameof(Expander)).OnTapped(e => frame.Navigate(typeof(ExpanderPage))),
                    new NavigationViewItem().Content(nameof(Grid)).OnTapped(e => frame.Navigate(typeof(GridPage))),
                    new NavigationViewItem().Content(nameof(ItemsRepeater)).OnTapped(e => frame.Navigate(typeof(ItemsRepeaterPage))),
                    new NavigationViewItem().Content(nameof(RadioButtons)).OnTapped(e => frame.Navigate(typeof(RadioButtonsPage))),
                    new NavigationViewItem().Content(nameof(RelativePanel)).OnTapped(e => frame.Navigate(typeof(RelativePanelPage))),
                    new NavigationViewItem().Content(nameof(SplitView)).OnTapped(e => frame.Navigate(typeof(SplitViewPage))),
                    new NavigationViewItem().Content(nameof(StackPanel)).OnTapped(e => frame.Navigate(typeof(StackPanelPage))),
                    new NavigationViewItem().Content(nameof(VariableSizedWrapGrid)).OnTapped(e => frame.Navigate(typeof(VariableSizedWrapGridPage))),                    
                    new NavigationViewItem().Content(nameof(Viewbox)).OnTapped(e => frame.Navigate(typeof(ViewboxPage))),
                },
                new NavigationViewItem
                {
                    e => e.Content("Text").Icon(new SymbolIcon(Symbol.Font)),

                    new NavigationViewItem().Content(nameof(AutoSuggestBox)).OnTapped(e => frame.Navigate(typeof(AutoSuggestBoxPage))),
                    new NavigationViewItem().Content(nameof(NumberBox)).OnTapped(e => frame.Navigate(typeof(NumberBoxPage))),
                    new NavigationViewItem().Content(nameof(PasswordBox)).OnTapped(e => frame.Navigate(typeof(PasswordBoxPage))),
                    new NavigationViewItem().Content(nameof(RichEditBox)).OnTapped(e => frame.Navigate(typeof(RichEditBoxPage))),
                    new NavigationViewItem().Content(nameof(RichTextBlock)).OnTapped(e => frame.Navigate(typeof(RichTextBlockPage))),
                    new NavigationViewItem().Content(nameof(TextBlock)).OnTapped(e => frame.Navigate(typeof(TextBlockPage))),
                    new NavigationViewItem().Content(nameof(TextBox)).OnTapped(e => frame.Navigate(typeof(TextBoxPage))),
                }
                //new NavigationViewItem().Content("Collections").Icon(new SymbolIcon(Symbol.List)),
                //new NavigationViewItem().Content("Data & Time").Icon(new SymbolIcon(Symbol.CalendarDay)),
                //new NavigationViewItem().Content("Navigation").Icon(new SymbolIcon(Symbol.GlobalNavigationButton)),
            }
            .Background(e => e.ResourceKey("BackgroundColor").Source(this))
            .Content(new Frame(out frame));             
            
            frame.Navigate(typeof(HomePage));
        }
    }
}
