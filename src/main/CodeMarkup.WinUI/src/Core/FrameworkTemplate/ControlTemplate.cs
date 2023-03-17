using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace CodeMarkup.WinUI
{
    public class ControlTemplate<TRoot> : FrameworkTemplate<ControlTemplate, TRoot>
        where TRoot : FrameworkElement
    {
        public ControlTemplate(TemplateBuildMethodWithParent<TRoot> build) : base(build)
        {
        }
    }
}
