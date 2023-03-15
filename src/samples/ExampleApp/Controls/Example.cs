using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml;
using CodeMarkup.WinUI;
using Microsoft.UI;
using Microsoft.UI.Xaml.Media;
using ColorCode;


namespace ExampleApp
{
    using CodeMarkup.WinUI.Controls;
    using CodeMarkup.WinUI.Styling;
    using System;

    [DependencyProperties]
    public interface IExample
    {
        public string Title { get; set; }
        public bool IsExpanded { get; set; }

        public UIElement ExampleContent { get; set; }

        [PropertyCallbacks(nameof(Example.SourceTextChanged))]
        public string SourceText { get; set; }
    }

    [MarkupObject]
    [ContainerProperty(nameof(ExampleContent))] 
    public partial class Example : Frame, IExample
    {
        private readonly RichTextBlock sourceTextBlock;        

        public Example()
        {
            this.Resources = new()
            {
                new ThemeColor { Key = "BackgroundColor", Light = Colors.LightBlue, Dark = Colors.MidnightBlue }
            };

            Content = new VStack(e => e.Padding(10))
            {
                new TextBlock()
                    .Text(e => e.Path(nameof(Title)).Source(this))
                    .FontSize(20)
                    .Margin(0,10,0,10),

                new Grid
                {
                    new Frame()
                        .Content(e => e.Path(nameof(ExampleContent))
                        .Source(this))
                }
                .Margin(1, 0, 1, 0)
                .Padding(20)
                .Background(e => e.ThemeResource("BackgroundColor").Source(this)),                
                
                new Expander
                {
                    new Grid
                    {
                        new RichTextBlock()
                            .Assign(out sourceTextBlock)
                            .FontFamily(new FontFamily("Consolas"))
                    }
                    .Padding(10, 0, 10, 0)
                    .Width(int.MaxValue)
                }
                .IsExpanded(e => e.Path(nameof(IsExpanded)).Source(this))
                .HorizontalAlignment(HorizontalAlignment.Stretch)
                .ExpandDirection(ExpandDirection.Down)
                .Header("Source code")
            };
        }

        public static void SourceTextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            var example = (Example)sender;
            var sourceText = e.NewValue as string;
            var formatter = new RichTextBlockFormatter(ElementTheme.Dark);
            formatter.FormatRichTextBlock(sourceText, Languages.CSharp, example.sourceTextBlock);
        }
    }
}
