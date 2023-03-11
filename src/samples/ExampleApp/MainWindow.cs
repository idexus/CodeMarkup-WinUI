using Microsoft.UI.Xaml;

namespace ExampleApp
{
    using CodeMarkup.WinUI.Controls;

    internal class MainWindow : Window
    {
        public MainWindow()
        {            
            ExtendsContentIntoTitleBar = true;
            Content = new Frame { new MainPage() };
        }
    }
}
