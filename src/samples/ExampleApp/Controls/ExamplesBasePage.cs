using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml;
using System.Collections.Generic;

namespace ExampleApp
{
    using CodeMarkup.WinUI;
    using CodeMarkup.WinUI.Controls;

    [DependencyProperties]
    public interface IExamplesBasePage
    {
        [PropertyCallbacks(nameof(ExamplesBasePage.TitleChanged))]
        public string Title { get; set; }

        [PropertyCallbacks(nameof(ExamplesBasePage.ExamplesChanged))]
        public List<Example> Examples { get; set; }
    }

    [MarkupObject]
    public partial class ExamplesBasePage : Page, IExamplesBasePage
    {
        private readonly VStack vstack;
        private readonly TextBlock titleTextBlock;

        public ExamplesBasePage()
        {
            Content = new ScrollViewer()
                .Content(new VStack(e => e.Margin(new Thickness(40)))
                {
                    new TextBlock()
                        .Assign(out titleTextBlock)
                        .FontSize(60)
                        .Margin(new Thickness(0,0,0,20)),

                    new VStack(out vstack)
                });
        }

        public static void TitleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            var basePage = (ExamplesBasePage)sender;
            var title = e.NewValue as string;
            basePage.titleTextBlock.Text = title;
        }

        public static void ExamplesChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            var basePage = (ExamplesBasePage)sender;
            var examples = e.NewValue as List<Example>;
            basePage.vstack.Children.Clear();
            foreach (var example in examples) 
                basePage.vstack.Children.Add(example);
        }
    }
}
