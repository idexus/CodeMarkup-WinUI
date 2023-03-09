using System.Collections.Generic;
using Microsoft.UI.Xaml.Controls;
using CodeOnly.WinUI.Core;
using Microsoft.UI.Xaml;
using Microsoft.UI;
using Microsoft.UI.Xaml.Markup;
using Microsoft.UI.Xaml.Media;

namespace ExampleApp
{
    using CodeOnly.WinUI;
    using System.Runtime.CompilerServices;

    public class ControlTemplateRoot : Grid
    {
        public static readonly DependencyProperty TemplatedParentProperty =
            DependencyProperty.Register(nameof(TemplatedParent),
            typeof(FrameworkElement),
            typeof(ControlTemplateRoot),
            new PropertyMetadata(default(FrameworkElement)));

        public FrameworkElement TemplatedParent
        {
            get => (FrameworkElement)GetValue(TemplatedParentProperty);
            set => SetValue(TemplatedParentProperty, value);
        }

        public ControlTemplateRoot()
        {
            this.RegisterPropertyChangedCallback(ControlTemplateRoot.TemplatedParentProperty, (sender, e) =>
            {
                BuildTemplate();
            });
        }

        public virtual void BuildTemplate() { }
    }

    public class ControlTemplate<TElement, TRoot>
        where TRoot : ControlTemplateRoot
    {
        string templateXamlString =>
        $@"<ControlTemplate TargetType=""{typeof(TElement).Name}""
            xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation""
            xmlns:root=""using:{typeof(TRoot).Namespace}"">
            <root:{typeof(TRoot).Name} TemplatedParent=""{{Binding RelativeSource={{RelativeSource TemplatedParent}}}}""/>
        </ControlTemplate>";

        ControlTemplate xamlControlTemplate => (ControlTemplate)XamlReader.Load(templateXamlString);
        public static implicit operator ControlTemplate(ControlTemplate<TElement, TRoot> templateBuilder) => templateBuilder.xamlControlTemplate;
    }

    public partial class MyButtonControlTemplateRoot : ControlTemplateRoot
    {
        public override void BuildTemplate()
        {
            this.Add(new Grid(e => e.VerticalAlignment(VerticalAlignment.Center))
            {
                new TextBlock().Text(e => e.Path("Content").Source(TemplatedParent))
            });

            this.AddVisualStateGroup("CommonStates", new List<VisualState>
            {
                new VisualState<Button>("PointerOver")
                {
                    new Setter { Target = new TargetPropertyPath { Path = new PropertyPath("Background"), Target = this }, Value = new SolidColorBrush(Colors.Red) },
                },

                new VisualState<Button>("Normal")
                {
                    new Setter { Target = new TargetPropertyPath { Path = new PropertyPath("Background"), Target = this }, Value = new SolidColorBrush(Colors.Gray) },
                }
            });
        }
    }

    internal class CodePage : Page
    {
        private readonly Button button;

        
        public CodePage() 
        {
            this.Content = new StackPanel
            {
                new Button()
                    .Assign(out button)
                    .FontSize(70)
                    .Content("Hello Button")
                    .Width(300)
                    .Height(300)
                    .Template(new ControlTemplate<Button, MyButtonControlTemplateRoot>()),

                new StackPanel(out var myPanel, e => e.Orientation(Orientation.Horizontal))
                {
                    new TextBlock().Text("Text 1"),
                    new TextBlock().Text("Text 2"),
                    new TextBlock().Text("Text 3"),
                    new TextBlock().Text("Text 4"),                    
                }
            }
            .AddVisualStateGroup(new List<VisualState> // must be defined in direct child of Page
            {
                new VisualState<StackPanel>()
                {
                    new Setter { Target = new TargetPropertyPath { Path = new PropertyPath("Orientation"), Target = myPanel }, Value = Orientation.Vertical },
                    new AdaptiveTrigger().MinWindowWidth(720)
                }
            });

            //this.AddVisualStateGroup("CommonStates", new List<VisualState>
            //    {
            //        new VisualState<Button>("PointerOver")
            //        {
            //            new Setter { Target = new TargetPropertyPath { Path = new PropertyPath("Background"), Target = this }, Value = new SolidColorBrush(Colors.Red) },
            //        },

            //        new VisualState<Button>("Normal")
            //        {
            //            new Setter { Target = new TargetPropertyPath { Path = new PropertyPath("Background"), Target = this }, Value = new SolidColorBrush(Colors.Gray) },
            //        }
            //    });
        }
    }
}
