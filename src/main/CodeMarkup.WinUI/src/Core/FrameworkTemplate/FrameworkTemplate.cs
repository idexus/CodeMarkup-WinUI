using System;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Markup;

namespace CodeMarkup.WinUI
{
    public delegate void TemplateBuildMethodWithParent<T>(T root, FrameworkElement parent) where T : FrameworkElement;
    public delegate void TemplateBuildMethod<T>(T root) where T : FrameworkElement;

    public abstract class FrameworkTemplate<TTemplate, TRoot>
        where TTemplate : FrameworkTemplate
        where TRoot : FrameworkElement
    {
        public static implicit operator TTemplate(FrameworkTemplate<TTemplate, TRoot> frameworkTemplate) => frameworkTemplate.xamlFrameworkTemplate;

        TTemplate xamlFrameworkTemplate;
        public FrameworkTemplate(TemplateBuildMethodWithParent<TRoot> build)
        {
            var guid = Guid.NewGuid().ToString();
            FrameworkTempateManager.HandlerMethodsWithParent[guid] = (root, parent) => build(root as TRoot, parent);
            CreateXamlFrameworkTemplate(guid);
        }

        public FrameworkTemplate(TemplateBuildMethod<TRoot> build)
        {
            var guid = Guid.NewGuid().ToString();
            FrameworkTempateManager.HandlerMethodsWithoutParent[guid] = root => build(root as TRoot);
            CreateXamlFrameworkTemplate(guid);
        }

        void CreateXamlFrameworkTemplate(string guid)
        {            
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
