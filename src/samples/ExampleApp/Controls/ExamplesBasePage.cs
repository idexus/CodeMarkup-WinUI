using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml;
using System.Collections.Generic;

namespace ExampleApp
{
    using CodeMarkup.WinUI;
    using CodeMarkup.WinUI.Controls;
    using CodeMarkup.WinUI.Styling;
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

            this.Resources = new()
            {
                new ThemeColor { Key = "HeaderColor", Light = Colors.Navy, Dark = Colors.Aqua },
                new ThemeColor { Key = "NamespaceColor", Light = Colors.Black, Dark = Colors.GhostWhite }
            }; 

            Content = new ScrollViewer()
                .Content(new VStack(e => e.Margin(40))
                {
                    new TextBlock()
                        .Assign(out titleTextBlock)
                        .Foreground(e => e.ThemeResource("HeaderColor").Source(this))
                        .FontSize(60)
                        .Margin(5,0,0,2),
                    
                    new HStack(e => e.Margin(10,0,0,20))
                    {
                        new TextBlock()
                            .Assign(out typeTextBlock)
                            .FontWeight(new FontWeight(200))
                            .Foreground(e => e.ThemeResource("NamespaceColor").Source(this))
                            .FontSize(13),

                        new TextBlock()
                            .Assign(out sealedTextBlock)
                            .FontWeight(new FontWeight(700))
                            .Foreground(Colors.Red)
                            .Margin(7,0,0,0)
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
