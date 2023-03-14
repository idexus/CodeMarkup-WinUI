using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml;
using System.Collections.Generic;

namespace ExampleApp
{
    using CodeMarkup.WinUI;
    using CodeMarkup.WinUI.Controls;
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

        public ExamplesBasePage()
        {
            Content = new ScrollViewer()
                .Content(new VStack(e => e.Margin(new Thickness(40)))
                {
                    new TextBlock()
                        .Assign(out titleTextBlock)
                        .FontSize(60)
                        .Margin(new Thickness(5,0,0,2)),
                    
                    new TextBlock()
                        .Assign(out typeTextBlock)
                        .FontWeight(new FontWeight(100))
                        .FontSize(13)
                        .Margin(new Thickness(10,0,0,25)),

                    new VStack(out vstack) 
                });
        }

        public static void TypeChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            var basePage = (ExamplesBasePage)sender;
            var type = (Type)e.NewValue;
            basePage.typeTextBlock.Text = type.Namespace.ToString();
            basePage.titleTextBlock.Text = type.Name;

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
