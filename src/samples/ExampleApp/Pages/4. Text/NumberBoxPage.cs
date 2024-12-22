using System;
using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media.Imaging;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Windows.Globalization.NumberFormatting;

namespace ExampleApp
{
    using CodeMarkup.WinUI;
    
    [Bindable]
    public partial class NumberBoxPage : ExamplesBasePage
    {
        public NumberBoxPage()
        {
            Type = typeof(NumberBox);

            Examples = new()
            {
                new Example
                {
                    new NumberBox()
                        .Width(300)
                        .Header("Expression:")
                        .Value(double.NaN)
                        .PlaceholderText("2*3 + 1")
                        .AcceptsExpression(true)
                }
                .Title("Evaluate expression")
                .SourceText(Sources.Sample1),

                new Example
                {
                    new NumberBox()
                        .Width(300)
                        .Header("Formatted value:")
                        .PlaceholderText("0.00")
                        .InvokeOnElement(box =>
                        {
                            var rounder = new IncrementNumberRounder { Increment = 0.25, RoundingAlgorithm = RoundingAlgorithm.RoundHalfUp };
                            box.NumberFormatter = new DecimalFormatter { IntegerDigits = 1, FractionDigits = 2, NumberRounder = rounder };
                        })
                }
                .Title("Formatted value")
                .SourceText(Sources.Sample2),

                new Example
                {
                    new NumberBox()
                        .Width(300)
                        .Header("Integer value:")
                        .Value(1)
                        .SpinButtonPlacementMode(NumberBoxSpinButtonPlacementMode.Inline)
                        .SmallChange(1)
                        .LargeChange(10)
                }
                .Title("Integer value")
                .SourceText(Sources.Sample3),
            };
        }
    }
}