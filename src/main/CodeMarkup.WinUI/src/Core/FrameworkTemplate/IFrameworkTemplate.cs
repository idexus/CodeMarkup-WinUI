using Microsoft.UI.Xaml;

namespace CodeMarkup.WinUI
{
    public interface IFrameworkTemplate
    {
        public void BuildTemplate();
    }

    public interface IFrameworkTemplateWithParent
    {
        public void BuildTemplate(FrameworkElement parent);
    }
}
