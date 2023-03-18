namespace ExampleApp
{
    public partial class AutoSuggestBoxPage
    {
        class Sources
        {
            public const string Sample1 =
$@"
readonly TextBlock selectionText;
List<string> Animals = new()
{{
    ""Dog"",
    ""Cat"",
    ...         
}};

// further in code

new HStack
{{
    new AutoSuggestBox()
        .Width(400)
        .OnTextChanged((box, args) =>
        {{
            if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
                box.ItemsSource = Animals.Where(e => e.ToLower().Contains(box.Text.ToLower())).ToList();
        }})
        .OnSuggestionChosen((box, args) => selectionText.Text = args.SelectedItem.ToString()),

    new TextBlock()
        .Assign(out selectionText)
        .Margin(10, 4)
}}";

        };
    }
}
