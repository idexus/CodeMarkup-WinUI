using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System.Collections.Generic;

namespace CodeOnly.WinUI
{
    public class RowDefinitionBuilder
    {
        public List<RowDefinition> Items { get; } = new List<RowDefinition>();

        public RowDefinitionBuilder Auto(int count = 1)
        {
            for (int i = 0; i < count; i++)
                Items.Add(new RowDefinition { Height = new GridLength(0, GridUnitType.Auto) });
            return this;
        }

        public RowDefinitionBuilder Star(double height = 1, int count = 1)
        {
            for (int i = 0; i < count; i++)
                Items.Add(new RowDefinition { Height = new GridLength(height, GridUnitType.Star) });
            return this;
        }

        public RowDefinitionBuilder Pixel(double height, int count = 1)
        {
            for (int i = 0; i < count; i++)
                Items.Add(new RowDefinition { Height = new GridLength(height, GridUnitType.Pixel) });
            return this;
        }
    }
}
