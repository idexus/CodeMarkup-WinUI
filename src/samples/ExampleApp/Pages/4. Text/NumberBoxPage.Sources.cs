namespace ExampleApp
{
    public partial class NumberBoxPage
    {
        class Sources
        {
            public const string Sample1 =
$@"new NumberBox()
    .Width(300)
    .Header(""Expression:"")
    .Value(double.NaN)
    .PlaceholderText(""2*3 + 1"")
    .AcceptsExpression(true)";

            public const string Sample2 =
$@"new NumberBox()
    .Width(300)
    .Header(""Formatted value:"")
    .PlaceholderText(""0.00"")
    .InvokeOnElement(box =>
    {{
        var rounder = new IncrementNumberRounder {{ Increment = 0.25, RoundingAlgorithm = RoundingAlgorithm.RoundHalfUp }};
        box.NumberFormatter = new DecimalFormatter {{ IntegerDigits = 1, FractionDigits = 2, NumberRounder = rounder }};
    }})";

            public const string Sample3 =
$@"new NumberBox()
    .Width(300)
    .Header(""Integer value:"")
    .Value(1)
    .SpinButtonPlacementMode(NumberBoxSpinButtonPlacementMode.Inline)
    .SmallChange(1)
    .LargeChange(10)";
        };
    }
}
