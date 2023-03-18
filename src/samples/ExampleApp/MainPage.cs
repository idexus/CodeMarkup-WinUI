using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Controls;
using CodeMarkup.WinUI;
namespace ExampleApp
{
    using CodeMarkup.WinUI.Controls;
    using CodeMarkup.WinUI.Styling;
    using Microsoft.UI.Xaml.Media;
    using Microsoft.UI.Xaml;
    using Microsoft.UI;
    using Windows.UI;

    internal class MainPage : Page
    {
        Frame frame;

        public MainPage() 
        {
            this.Resources.MergedDictionaries.Add(new()
            {
                new ThemeValue<Color> { Key = "BackgroundColor", Dark = Colors.Black, Light = Colors.LightBlue }
            });

            this.Content = new NavigationView(out var navigation)
            {
                new NavigationViewItem().Content("Home").Icon(new SymbolIcon(Symbol.Home)).OnTapped(e => frame.Content = new HomePage()),
                //new NavigationViewItem().Content("Test").OnTapped(e => frame.Content = new TestPage()),
                new NavigationViewItem
                {
                    e => e.Content("Fundamentals").Icon(new SymbolIcon(Symbol.Important)),

                    new NavigationViewItem().Content("Fluent methods").OnTapped(e => frame.Content = new FluentMethodsPage()),
                    new NavigationViewItem().Content("Containers").OnTapped(e => frame.Content = new ContainersPage()),
                    new NavigationViewItem().Content("Property Bindings").OnTapped(e => frame.Content = new PropertyBindingsPage()),
                    new NavigationViewItem().Content("Resources").OnTapped(e => frame.Content = new ResourcesPage()),
                    new NavigationViewItem().Content("Styling").OnTapped(e => frame.Content = new StylingPage()),
                },
                new NavigationViewItem
                {
                    e => e.Content("Basic Input").Icon(new SymbolIcon(Symbol.Accept)),

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
                new NavigationViewItem
                {
                    e => e.Content("Layout").Icon(new SymbolIcon(Symbol.ViewAll)),

                    new NavigationViewItem().Content(nameof(Border)).OnTapped(e => frame.Content = new BorderPage()),
                    new NavigationViewItem().Content(nameof(Canvas)).OnTapped(e => frame.Content = new CanvasPage()),
                    new NavigationViewItem().Content(nameof(Expander)).OnTapped(e => frame.Content = new ExpanderPage()),
                    new NavigationViewItem().Content(nameof(Grid)).OnTapped(e => frame.Content = new GridPage()),
                    new NavigationViewItem().Content(nameof(ItemsRepeater)).OnTapped(e => frame.Content = new ItemsRepeaterPage()),
                    new NavigationViewItem().Content(nameof(RadioButtons)).OnTapped(e => frame.Content = new RadioButtonsPage()),
                    new NavigationViewItem().Content(nameof(RelativePanel)).OnTapped(e => frame.Content = new RelativePanelPage()),
                    new NavigationViewItem().Content(nameof(SplitView)).OnTapped(e => frame.Content = new SplitViewPage()),
                    new NavigationViewItem().Content(nameof(StackPanel)).OnTapped(e => frame.Content = new StackPanelPage()),
                    new NavigationViewItem().Content(nameof(VariableSizedWrapGrid)).OnTapped(e => frame.Content = new VariableSizedWrapGridPage()),                    
                    new NavigationViewItem().Content(nameof(Viewbox)).OnTapped(e => frame.Content = new ViewboxPage()),
                },
                new NavigationViewItem
                {
                    e => e.Content("Text").Icon(new SymbolIcon(Symbol.Font)),

                    new NavigationViewItem().Content(nameof(AutoSuggestBox)).OnTapped(e => frame.Content = new AutoSuggestBoxPage()),
                    new NavigationViewItem().Content(nameof(NumberBox)).OnTapped(e => frame.Content = new NumberBoxPage()),
                    new NavigationViewItem().Content(nameof(PasswordBox)).OnTapped(e => frame.Content = new PasswordBoxPage()),
                    new NavigationViewItem().Content(nameof(RichEditBox)).OnTapped(e => frame.Content = new RichEditBoxPage()),
                    new NavigationViewItem().Content(nameof(RichTextBlock)).OnTapped(e => frame.Content = new RichTextBlockPage()),
                    new NavigationViewItem().Content(nameof(TextBlock)).OnTapped(e => frame.Content = new TextBlockPage()),
                    new NavigationViewItem().Content(nameof(TextBox)).OnTapped(e => frame.Content = new TextBoxPage()),
                }
                //new NavigationViewItem().Content("Collections").Icon(new SymbolIcon(Symbol.List)),
                //new NavigationViewItem().Content("Data & Time").Icon(new SymbolIcon(Symbol.CalendarDay)),
                //new NavigationViewItem().Content("Navigation").Icon(new SymbolIcon(Symbol.GlobalNavigationButton)),
            }
            .Background(e => e.ResourceKey("BackgroundColor").Source(this))
            .Content(new Frame(out frame) 
            {
                new HomePage()
            });                
        }
    }
}