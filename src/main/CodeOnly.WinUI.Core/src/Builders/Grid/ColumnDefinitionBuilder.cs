using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System.Collections.Generic;

namespace CodeOnly.WinUI.Core
{
    public class ColumnDefinitionBuilder
    {
        public List<ColumnDefinition> Items { get; } = new List<ColumnDefinition>();

        public ColumnDefinitionBuilder Auto(int count = 1)
        {
            for (int i = 0; i < count; i++)
                Items.Add(new ColumnDefinition { Width = new GridLength(0, GridUnitType.Auto) });
            return this;
        }

        public ColumnDefinitionBuilder Star(double width = 1, int count = 1)
        {
            for (int i = 0; i < count; i++)
                Items.Add(new ColumnDefinition { Width = new GridLength(width, GridUnitType.Star) });
            return this;
        }

        public ColumnDefinitionBuilder Pixel(double width, int count = 1)
        {
            for (int i = 0; i < count; i++)
                Items.Add(new ColumnDefinition { Width = new GridLength(width, GridUnitType.Pixel) });
            return this;
        }
    }
}
