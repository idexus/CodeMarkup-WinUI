using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml;
using System.Collections.Generic;

namespace ExampleApp
{
    using CodeMarkup.WinUI;
    using CodeMarkup.WinUI.Controls;
    using Microsoft.UI;
    using Microsoft.UI.Xaml.Media;
    using System;
    using Windows.UI.Text;

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
            Content = new ScrollViewer()
                .Content(new VStack(e => e.Margin(40))
                {
                    new TextBlock()
                        .Assign(out titleTextBlock)
                        .Foreground(Colors.LightSkyBlue)
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
