using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml;
using System.Collections.Generic;

namespace ExampleApp
{
    using CodeMarkup.WinUI;
    using CodeMarkup.WinUI.Controls;
    using Microsoft.UI;
    using Microsoft.UI.Xaml.Data;
    using Microsoft.UI.Xaml.Media;
    using System;
    using System.ComponentModel;
    using System.Linq;
    using System.Threading.Tasks;
    using Windows.UI;
    using Windows.UI.Text;
    using Windows.UI.ViewManagement;

    public class DictionaryKeyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is ResourceDictionary dictionary && parameter is string key)
            {
                return dictionary[key];
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }

    public class ThemeDictionary : ResourceDictionary, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
    }

    [DependencyProperties]
    public interface IExamplesBasePage
    {
        [PropertyCallbacks(nameof(ExamplesBasePage.TypeChanged))]
        public Type Type { get; set; }

        [PropertyCallbacks(nameof(ExamplesBasePage.ExamplesChanged))]
        public List<Example> Examples { get; set; }
    }

    [MarkupObject]
    public partial class ExamplesBasePage : Page, IExamplesBasePage
    {
        private readonly VStack vstack;
        private readonly TextBlock titleTextBlock;
        private readonly TextBlock typeTextBlock;
        private readonly TextBlock sealedTextBlock;


        public ExamplesBasePage()
        {
            this.Resources.ThemeDictionaries["Light"] = new ResourceDictionary
            {
                ["HeaderColor"] = new SolidColorBrush(Colors.Blue)
            };

            this.Resources.ThemeDictionaries["Dark"] = new ResourceDictionary
            {
                ["HeaderColor"] = new SolidColorBrush(Colors.Red)
            };            

            Content = new ScrollViewer()
                .Content(new VStack(e => e.Margin(40))
                {
                    new TextBlock()
                        .Assign(out titleTextBlock)
                        .Foreground(e => e.Path(nameof(ThemeResources)).Source(this).DictionaryKey("HeaderColor"))
                        .FontSize(60)
                        .Margin(5,0,0,2),
                    
                    new HStack(e => e.Margin(10,0,0,20))
                    {
                        new TextBlock()
                            .Assign(out typeTextBlock)
                            .FontWeight(new FontWeight(150))
                            .Foreground(Colors.GhostWhite)
                            .FontSize(13),

                        new TextBlock()
                            .Assign(out sealedTextBlock)
                            .FontWeight(new FontWeight(700))
                            .Foreground(Colors.Red)
                            .Margin(10,0,0,0)
                            .FontSize(13),
                    },

                    new VStack(out vstack) 
                });
        }

        public static void TypeChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            var basePage = (ExamplesBasePage)sender;
            var type = (Type)e.NewValue;
            basePage.typeTextBlock.Text = type.Namespace.ToString();
            basePage.titleTextBlock.Text = type.Name;
            basePage.sealedTextBlock.Text = type.IsSealed ? "sealed" : "";

        }

        public static void ExamplesChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            var basePage = (ExamplesBasePage)sender;
            var examples = e.NewValue as List<Example>;
            basePage.vstack.Children.Clear();
            bool first = true;
            foreach (var example in examples)
            {
                example.IsExpanded = first;
                basePage.vstack.Children.Add(example);
                first = false;
            }
        }
    }
}
