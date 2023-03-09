using System.Collections.Generic;
using Microsoft.UI.Xaml.Controls;
using CodeOnly.WinUI.Core;
using Microsoft.UI.Xaml;
using Microsoft.UI;
using Microsoft.UI.Xaml.Markup;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Data;
using System;

namespace ExampleApp
{
    using CodeOnly.WinUI;

    public delegate void ControlTemplateHandler(Grid grid, FrameworkElement parent);

    [Bindable]
    public class ControlTemplateBuilder
    {
        internal static Dictionary<string, ControlTemplateHandler> Handlers = new Dictionary<string, ControlTemplateHandler>();

        // TemplatedParent

        public static readonly DependencyProperty TemplatedParentProperty =
            DependencyProperty.RegisterAttached("TemplatedParent",
            typeof(FrameworkElement),
            typeof(ControlTemplateBuilder),
            new PropertyMetadata(default(FrameworkElement), TemplatedParentCallback));

        public static void SetTemplatedParent(DependencyObject obj, FrameworkElement value)
        {
            obj.SetValue(TemplatedParentProperty, value);
        }

        public static FrameworkElement GetTemplatedParent(DependencyObject obj)
        {
            return (FrameworkElement)obj.GetValue(TemplatedParentProperty);
        }

        private static void TemplatedParentCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var handlerId = d.GetValue(HandlerIdProperty) as string;
            if (handlerId != null && d is Grid grid)
            {
                if (Handlers.TryGetValue(handlerId, out var handler))
                {
                    handler(grid, e.NewValue as FrameworkElement);
                }
            }
        }

        // HandlerId

        public static readonly DependencyProperty HandlerIdProperty =
            DependencyProperty.RegisterAttached("HandlerId",
            typeof(string),
            typeof(ControlTemplateBuilder),
            new PropertyMetadata(default(string)));

        public static void SetHandlerId(DependencyObject obj, string value)
        {
            obj.SetValue(HandlerIdProperty, value);
        }

        public static string GetHandlerId(DependencyObject obj)
        {
            return (string)obj.GetValue(HandlerIdProperty);
        }
    }

    public class ControlTemplate<TElement>
    {
        public static implicit operator ControlTemplate(ControlTemplate<TElement> templateBuilder) => templateBuilder.xamlControlTemplate;

        readonly ControlTemplate xamlControlTemplate;
        public ControlTemplate(ControlTemplateHandler handler)
        {
            var guid = Guid.NewGuid().ToString();
            ControlTemplateBuilder.Handlers[guid] = handler;

            var xamlControlTemplateString =
            $@"<ControlTemplate TargetType=""{typeof(TElement).Name}""
                xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation""
                xmlns:root=""using:ExampleApp""
                xmlns:code=""using:CodeOnly.WinUI"">
                <code:Grid root:ControlTemplateBuilder.HandlerId=""{guid}"" root:ControlTemplateBuilder.TemplatedParent=""{{Binding RelativeSource={{RelativeSource TemplatedParent}}}}""/>
            </ControlTemplate>";
            xamlControlTemplate = (ControlTemplate)XamlReader.Load(xamlControlTemplateString);
        }
    }

    internal class CodePage : Page
    {
        private readonly Button button;

        public CodePage() 
        {
            var controlTemplate = new ControlTemplate<Button>((grid, parent) =>
            {
                grid.Add(
                    new Grid(e => e
                        .VerticalAlignment(VerticalAlignment.Center)
                        .HorizontalAlignment(HorizontalAlignment.Center))
                    {
                        new TextBlock().Text(e => e.Path("Content").Source(parent))
                    });

                grid.AddVisualStateGroup("CommonStates", new List<VisualState>
                {
                    new VisualState<Button>("PointerOver")
                    {
                        new Setter { Target = new TargetPropertyPath { Path = new PropertyPath("Background"), Target = grid }, Value = new SolidColorBrush(Colors.Red) },
                    },

                    new VisualState<Button>("Normal")
                    {
                        new Setter { Target = new TargetPropertyPath { Path = new PropertyPath("Background"), Target = grid }, Value = new SolidColorBrush(Colors.Gray) },
                    }
                });
            });

            this.Content = new StackPanel
            {
                new Button()
                    .Assign(out button)
                    .FontSize(70)
                    .Content("Hello Button")
                    .Width(300)
                    .Height(300)
                    .Template(controlTemplate),

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
        }
    }
}
