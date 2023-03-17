using System;
using Microsoft.UI.Xaml;

namespace CodeMarkup.WinUI
{
    public class DataTemplate<TRoot> : FrameworkTemplate<DataTemplate, TRoot>
        where TRoot : FrameworkElement
    {
        public DataTemplate(TemplateBuildMethod<TRoot> build) : base(build)
        {
        }
    }
}
