using Microsoft.UI.Xaml.Controls;
using System.Collections;

namespace CodeMarkup.WinUI
{
    public static partial class GridExtension
    {
        public static T RowDefinitions<T>(this T self, System.Action<RowDefinitionBuilder> configure)
            where T : Grid
        {
            var builder = new RowDefinitionBuilder();
            configure(builder);
            foreach (var rowDef in builder.Items)
                self.RowDefinitions.Add(rowDef);
            return self;
        }

        public static T ColumnDefinitions<T>(this T self, System.Action<ColumnDefinitionBuilder> configure)
            where T : Grid
        {
            var builder = new ColumnDefinitionBuilder();
            configure(builder);
            foreach (var colDef in builder.Items)
                self.ColumnDefinitions.Add(colDef);
            return self;
        }

        public static T Spacing<T>(this T self, double columnSpacing, double rowSpacing)
            where T : Grid
        {
            self.SetValue(Grid.ColumnSpacingProperty, columnSpacing);
            self.SetValue(Grid.RowSpacingProperty, rowSpacing);
            return self;
        }

        public static T Spacing<T>(this T self, double spacing)
            where T : Grid
        {
            self.SetValue(Grid.ColumnSpacingProperty, spacing);
            self.SetValue(Grid.RowSpacingProperty, spacing);
            return self;
        }
    }
}
