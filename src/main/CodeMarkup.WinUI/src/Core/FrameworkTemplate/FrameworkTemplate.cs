using System;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Markup;

namespace CodeMarkup.WinUI
{
    public class FrameworkTemplate<TTemplate, TRoot>
        where TTemplate : FrameworkTemplate
        where TRoot : FrameworkElement
    {
        public static implicit operator TTemplate(FrameworkTemplate<TTemplate, TRoot> frameworkTemplate) => frameworkTemplate.xamlFrameworkTemplate;

        readonly TTemplate xamlFrameworkTemplate;
        public FrameworkTemplate()
        {
            var guid = Guid.NewGuid().ToString();
            FrameworkTempateManager.HandlerMethods[guid] = (FrameworkElement parent, FrameworkElement root) =>
            {
                if (root is IFrameworkTemplate rootWithoutParent)
                    rootWithoutParent.BuildTemplate();
                else if (root is IFrameworkTemplateWithParent rootWithParent)
                    rootWithParent.BuildTemplate(parent);
            };

            var xamlControlTemplateString =
$@"<{typeof(TTemplate).Name}
    xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation""
    xmlns:root=""using:{typeof(TRoot).Namespace}""
    xmlns:manager=""using:{typeof(FrameworkTempateManager).Namespace}"">

    <root:{typeof(TRoot).Name} 
        manager:{typeof(FrameworkTempateManager).Name}.MethodId=""{guid}"" 
        manager:{typeof(FrameworkTempateManager).Name}.TemplatedParent=""{{Binding RelativeSource={{RelativeSource TemplatedParent}}}}""/>

</{typeof(TTemplate).Name}>";
            xamlFrameworkTemplate = (TTemplate)XamlReader.Load(xamlControlTemplateString);
        }
    }
}
