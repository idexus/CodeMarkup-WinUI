using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml.Controls;
using CodeOnly.WinUI.Core;
using Microsoft.UI.Xaml;

namespace ExampleApp
{
    using CodeOnly.WinUI;
    using Microsoft.UI;
    using Microsoft.UI.Xaml.Data;
    using Microsoft.UI.Xaml.Markup;
    using Microsoft.UI.Xaml.Media;
    using System.Reflection.Emit;
    using System.Security;
    using System.Xml.Linq;


    [DependencyProperties]
    public interface IMyTemplate
    {
        public FrameworkElement TemplatedParent { get; set; }
    }

    [SharpObject]
    public partial class MyTemplate : Grid, IMyTemplate
    {
        public MyTemplate()
        {
            this.RegisterPropertyChangedCallback(MyTemplate.TemplatedParentProperty, (sender, e) =>
            {
                this.Add(
                    new Grid(e => e.VerticalAlignment(VerticalAlignment.Center))
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
            });
        }
    }

    internal class CodePage : Page
    {
        private readonly Button button;

        
        private ControlTemplate GetTemplate()
        {
            string template =
                $@"
                <ControlTemplate TargetType =""Button""
                    xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation""
                    xmlns:root=""using:{this.GetType().Namespace}"">
                    
                    <root:MyTemplate TemplatedParent=""{{Binding RelativeSource={{RelativeSource TemplatedParent}}}}""/>

                </ControlTemplate>";
             return (ControlTemplate)XamlReader.Load(template);
        }


        public CodePage() 
        {
            var buttonControlTemplate = new ControlTemplate { TargetType = typeof(Button) };

            this.Content = new StackPanel
            {
                new Button()
                    .Assign(out button)
                    .FontSize(70)
                    .Content("Hello Button")
                    .Width(300)
                    .Height(300)
                    .Template(GetTemplate()),//(ControlTemplate)null),

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
                    //new Setter { Target = new TargetPropertyPath { Path = new PropertyPath("FontSize"), Target = button }, Value = 48 },
                    new Setter { Target = new TargetPropertyPath { Path = new PropertyPath("Orientation"), Target = myPanel }, Value = Orientation.Vertical },
                    new AdaptiveTrigger().MinWindowWidth(720)
                }
            });
        }
    }
}
