using System;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media.Imaging;
using Microsoft.UI.Xaml.Controls.Primitives;

namespace ExampleApp
{
    using CodeMarkup.WinUI;
    using CodeMarkup.WinUI.Controls;
    using Microsoft.UI;
    using Microsoft.UI.Xaml;
    using Microsoft.UI.Xaml.Media;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public partial class ComboBoxPage : ExamplesBasePage
    {
        public List<string> Items { get; set; } = new()
        {
            "Paul",
            "Alice",
            "John",
            "Max"
        };

        public ComboBoxPage()
        {
            Type = typeof(ComboBox);
           
            Examples = new()
            {
                new Example
                {
                    new ComboBox
                    {
                        "Car",
                        "Home",
                        "Door",
                        "Window"
                    }
                    .PlaceholderText("Pick a thing")
                    .Width(250)
                    .OnSelectionChanged(combo => combo.PlaceholderText = combo.SelectedValue as string),
                }
                .Title("A ComboBox with items defined inline")
                .SourceText(Sources.SimpleComboBox),

                new Example
                {
                    new ComboBox()
                        .ItemsSource(e => e.Path(nameof(Items)).Source(this))
                        .PlaceholderText("Pick a name")
                        .Width(250)
                        .OnSelectionChanged(combo => combo.PlaceholderText = combo.SelectedValue as string),
                }
                .Title("A ComboBox with a items source")
                .SourceText(Sources.ComboBoxWithItemSource),
            };
        }
    }
}

