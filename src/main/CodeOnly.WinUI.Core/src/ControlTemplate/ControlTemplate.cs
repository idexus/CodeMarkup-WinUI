using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Markup;
using System;

namespace CodeOnly.WinUI.Core
{
    public class ControlTemplate<TElement, TPanel>
        where TElement : FrameworkElement
        where TPanel : Panel
    {
        public static implicit operator ControlTemplate(ControlTemplate<TElement, TPanel> templateBuilder) => templateBuilder.xamlControlTemplate;

        readonly ControlTemplate xamlControlTemplate;
        public ControlTemplate(Action<TElement, TPanel> handlerMethod)
        {
            var guid = Guid.NewGuid().ToString();
            ControlTemplateHandler.HandlerMethods[guid] = (FrameworkElement element, Panel panel) => handlerMethod(element as TElement, panel as TPanel);

            var xamlControlTemplateString =
$@"<ControlTemplate TargetType=""{typeof(TElement).Name}""
    xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation""
    xmlns:panel=""using:{typeof(TPanel).Namespace}""
    xmlns:code=""using:{typeof(ControlTemplateHandler).Namespace}"">

    <panel:{typeof(TPanel).Name} 
        code:{typeof(ControlTemplateHandler).Name}.MethodId=""{guid}"" 
        code:{typeof(ControlTemplateHandler).Name}.TemplatedParent=""{{Binding RelativeSource={{RelativeSource TemplatedParent}}}}""/>

</ControlTemplate>";
            xamlControlTemplate = (ControlTemplate)XamlReader.Load(xamlControlTemplateString);
        }
    }
}
