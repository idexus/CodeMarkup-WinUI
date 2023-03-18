using System;
using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media.Imaging;
using Microsoft.UI.Xaml.Controls.Primitives;

namespace ExampleApp
{
    using CodeMarkup.WinUI;
    using CodeMarkup.WinUI.Controls;
    using System.Collections.Generic;
    using System.Linq;

    public partial class AutoSuggestBoxPage : ExamplesBasePage
    {
        readonly TextBlock selectionText;
        List<string> Animals = new()
        {
            "Dog",
            "Cat",
            "Elephant",
            "Monkey",
            "Mouse",
            "Horse",
            "Zebra",           
        };

        public AutoSuggestBoxPage()
        {
            Type = typeof(AutoSuggestBox);

            Examples = new()
            {
                new Example
                {
                    new HStack
                    {
                        new AutoSuggestBox()
                            .Width(400)
                            .OnTextChanged((box, args) =>
                            {
                                if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
                                    box.ItemsSource = Animals.Where(e => e.ToLower().Contains(box.Text.ToLower())).ToList();
                            })
                            .OnSuggestionChosen((box, args) => selectionText.Text = args.SelectedItem.ToString()),

                        new TextBlock()
                            .Assign(out selectionText)
                            .Margin(10, 4)
                    }
                }
                .Title("Auto suggest")
                .SourceText(Sources.Sample1),
            };
        }
    }
}