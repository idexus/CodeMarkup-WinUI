namespace ExampleApp
{
    public partial class CheckBoxPage
    {
        class Sources
        {
            public const string TwoState =
$@"new CheckBox()
    .Content(""Two-state CheckBox"")
    .OnChecked(checkBox => 
    {{ 
        // checked - do some stuff 
    }})
    .OnUnchecked(checkBox =>
    {{ 
        // unchecked - do some stuff
    }})";

            public const string ThreeState =
$@"new CheckBox()
    .Content(""Three-state CheckBox"")
    .IsThreeState(true)
    .OnChecked(checkBox => {{ }})
    .OnUnchecked(checkBox => {{ }})
    .OnIndeterminate(checkBox => {{ }})";
        };
    }
}
