using System;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Markup;

namespace CodeMarkup.WinUI
{
    public class FrameworkTemplate<TTemplate, TRoot>
        where TTemplate : FrameworkTemplate
        where TRoot : FrameworkElement, IFrameworkTemplate, new()
    {
        public static implicit operator TTemplate(FrameworkTemplate<TTemplate, TRoot> frameworkTemplate) => frameworkTemplate.xamlFrameworkTemplate;

        readonly TTemplate xamlFrameworkTemplate;
        public FrameworkTemplate()
        {
            var guid = Guid.NewGuid().ToString();
            FrameworkTempateManager.HandlerMethods[guid] = (FrameworkElement parent, FrameworkElement root) 
                => ((IFrameworkTemplate)root).BuildTemplate(parent);
            
            var xamlControlTemplateString =
$@"<{typeof(TTemplate).Name}
    xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation""
    xmlns:root=""using:{typeof(TRoot).Namespace}""
    xmlns:handler=""using:{typeof(FrameworkTempateManager).Namespace}"">

    <root:{typeof(TRoot).Name} 
        handler:{typeof(FrameworkTempateManager).Name}.MethodId=""{guid}"" 
        handler:{typeof(FrameworkTempateManager).Name}.TemplatedParent=""{{Binding RelativeSource={{RelativeSource TemplatedParent}}}}""/>

</{typeof(TTemplate).Name}>";
            xamlFrameworkTemplate = (TTemplate)XamlReader.Load(xamlControlTemplateString);
        }
    }
}
