namespace ExampleApp
{
    public partial class RatingControlPage
    {
        class Sources
        {
            public const string SimpleRatingControl =
$@"new RatingControl()
    .IsClearEnabled(false)
    .IsReadOnly(false)
    .Caption(""128 ratings"")                        
    .OnTapped(rc => 
    {{
        if (rc.IsReadOnly == false)
        {{
            rc.IsReadOnly = true;
            rc.Caption(""Your rating"");
        }}
    }})";

        };
    }
}
