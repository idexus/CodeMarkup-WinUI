namespace ExampleApp
{
    public partial class CanvasPage
    {
        class Sources
        {
            public const string SampleCode =
$@"new Canvas(e => e.Width(200).Height(200).Background(Colors.Gray))
{{
    new Rectangle()
        .Fill(Colors.Red)
        .Width(20).Height(20)
        .CanvasLeft(0).CanvasTop(0).CanvasZIndex(0),

    new Rectangle()
        .Fill(Colors.Green)
        .Width(20).Height(20)
        .CanvasLeft(0).CanvasTop(0).CanvasZIndex(0),
                        
    new Rectangle()
        .Fill(Colors.Blue)
        .Width(20).Height(20)
        .CanvasLeft(0).CanvasTop(0).CanvasZIndex(0)
}}";

        };
    }
}
