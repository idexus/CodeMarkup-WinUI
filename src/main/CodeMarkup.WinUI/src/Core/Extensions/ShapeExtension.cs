namespace CodeMarkup.WinUI
{
    [AttachedProperties(typeof(Microsoft.UI.Xaml.Controls.Canvas))]
    public interface IShapeCanvasAttachedProperties
    {
        [AttachedName("LeftProperty")]
        double CanvasLeft { get; set; }

        [AttachedName("TopProperty")]
        double CanvasTop { get; set; }

        [AttachedName("ZIndexProperty")]
        double CanvasZIndex { get; set; }
    }

    [AttachedInterfaces(typeof(Microsoft.UI.Xaml.Shapes.Shape), new[] { typeof(IShapeCanvasAttachedProperties) })]
    public static partial class ShapeExtension
    {
        
    }
}
