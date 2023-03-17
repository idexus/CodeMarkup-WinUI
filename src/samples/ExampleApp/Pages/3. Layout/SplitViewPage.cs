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
    using CodeMarkup.WinUI.Styling;
    using System.Collections.Generic;

    public partial class SplitViewPage : ExamplesBasePage
    {
        public class NavLink
        {
            public Symbol LinkSymbol { get; set; }
            public string Label { get; set; }

            public static List<NavLink> Links = new List<NavLink>
            {
                new NavLink { LinkSymbol = Symbol.Link, Label = "Link" },
                new NavLink { LinkSymbol = Symbol.Play, Label = "Play" },
                new NavLink { LinkSymbol = Symbol.Stop, Label = "Stop" },
            };
        }

        static readonly DataTemplate navLinkItemTemplate = new DataTemplate<Frame>(root =>
        {
            root.Content = new HStack
            {
                new SymbolIcon().Symbol(e => e.Path("LinkSymbol")).Margin(10,0),
                new TextBlock().Text(e => e.Path("Label"))
            };
        });
        private readonly TextBlock textBlock;

        public SplitViewPage()
        {
            Type = typeof(SplitView);

            Examples = new()
            {
                new Example
                {
                    new SplitView()
                        .PaneBackground(e => e.ResourceKey("SystemControlBackgroundChromeMediumLowBrush").Source(this))
                        .IsPaneOpen(true)
                        .OpenPaneLength(250)
                        .CompactPaneLength(50)
                        .DisplayMode(SplitViewDisplayMode.Inline)
                        .Pane(new Grid
                        {
                            e => e.RowDefinitions(e => e.Auto().Star().Auto()),

                            new TextBlock().Text("Menu").Margin(60,12,0,0),

                            new ListView()
                                .Row(1)
                                .SelectionMode(ListViewSelectionMode.Single)
                                .ItemsSource(NavLink.Links)
                                .ItemTemplate(navLinkItemTemplate)
                                .OnSelectionChanged(listView => 
                                {
                                    var link = (NavLink)listView.SelectedItem;
                                    textBlock.Text = link.Label;
                                })
                        })
                        .Content(new Grid
                        {
                            new TextBlock()
                                .HorizontalAlignment(HorizontalAlignment.Center)
                                .VerticalAlignment(VerticalAlignment.Center)
                                .Assign(out textBlock)
                                .FontSize(50)
                        })
                }
                .Title("")
                .SourceText(Sources.Sample1),
            };
        }
    }
}