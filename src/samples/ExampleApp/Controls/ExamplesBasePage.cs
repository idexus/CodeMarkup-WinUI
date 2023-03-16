using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml;
using System.Collections.Generic;
using Microsoft.UI;
using System;
using System.ComponentModel;
using Windows.UI.Text;


namespace ExampleApp
{
    using CodeMarkup.WinUI;
    using CodeMarkup.WinUI.Controls;
    using CodeMarkup.WinUI.Styling;
    using Windows.UI;

    [DependencyProperties]
    public interface IExamplesBasePage
    {
        [PropertyCallbacks(nameof(ExamplesBasePage.TitleChanged))]
        public string Title { get; set; }

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
        private readonly HStack namespaceHStack;
        private readonly VStack mainVStack;

        public ExamplesBasePage()
        {
            this.Resources.MergedDictionaries.Add(new()
            {
                new ThemeValue<Color> { Key = "HeaderColor", Light = Colors.Navy, Dark = Colors.Aqua },
                new ThemeValue<Color> { Key = "NamespaceColor", Light = Colors.Black, Dark = Colors.GhostWhite }
            });

            Content = new ScrollViewer()
                .Content(new VStack(out mainVStack, e => e.Margin(40))
                {
                    new TextBlock()
                        .Assign(out titleTextBlock)
                        .Foreground(e => e.ResourceKey("HeaderColor").Source(this))
                        .FontSize(52)
                        .Margin(5,0,0,2),
                    
                    new HStack(out namespaceHStack, e => e.Margin(10,0,0,20))
                    {
                        new TextBlock()
                            .Assign(out typeTextBlock)
                            .FontWeight(new FontWeight(200))
                            .Foreground(e => e.ResourceKey("NamespaceColor").Source(this))
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

        public static void TitleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            var basePage = (ExamplesBasePage)sender;
            basePage.titleTextBlock.Text = (string)e.NewValue;
            basePage.mainVStack.Children.Remove(basePage.namespaceHStack);
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
