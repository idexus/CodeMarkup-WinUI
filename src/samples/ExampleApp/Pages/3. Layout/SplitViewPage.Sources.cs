namespace ExampleApp
{
    public partial class SplitViewPage
    {
        class Sources
        {
            public const string Sample1 =
$@"new SplitView()
    .PaneBackground(e => e.ResourceKey(""SystemControlBackgroundChromeMediumLowBrush"").Source(this))
    .IsPaneOpen(true)
    .OpenPaneLength(250)
    .CompactPaneLength(50)
    .DisplayMode(SplitViewDisplayMode.Inline)
    .Pane(new Grid
    {{
        e => e.RowDefinitions(e => e.Auto().Star().Auto()),

        new TextBlock().Text(""Menu"").Margin(60,12,0,0),

        new ListView()
            .Row(1)
            .SelectionMode(ListViewSelectionMode.Single)
            .ItemsSource(NavLink.Links)
            .ItemTemplate(navLinkItemTemplate)
            .OnSelectionChanged(listView => 
            {{
                var link = (NavLink)listView.SelectedItem;
                textBlock.Text = link.Label;
            }})
    }})
    .Content(new Grid
    {{
        new TextBlock()
            .HorizontalAlignment(HorizontalAlignment.Center)
            .VerticalAlignment(VerticalAlignment.Center)
            .Assign(out textBlock)
            .FontSize(50)
    }})

// data template declaration (static field)

static readonly DataTemplate navLinkItemTemplate = new DataTemplate<Frame>(root =>
{{
    root.Content = new HStack
    {{
        new SymbolIcon().Symbol(e => e.Path(""LinkSymbol"")).Margin(10,0),
        new TextBlock().Text(e => e.Path(""Label""))
    }};
}});";

        };
    }
}
