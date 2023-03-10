using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using CodeOnly.WinUI;

namespace ExampleApp
{
    using CodeOnly.WinUI.Controls;
    using Microsoft.UI;
    using Microsoft.UI.Xaml.Media;
    using Microsoft.UI.Xaml.Media.Animation;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    [DependencyProperties]
    public interface IMyObject
    {
        public string Name { get; set; }
    }

    [SharpObject]
    public partial class MyObject : DependencyObject, IMyObject
    {
    
    }


    internal class BlankWindow : Window
    {
        public bool active { get; set; } = false;

        public string text { get; set; } = "DZIALA";
        ResourceDictionary res = new ResourceDictionary
        {
            {
                typeof(Microsoft.UI.Xaml.Controls.Button),
                //"MyButton",
                ((Style)(new Style<Button>(e => e.FontSize(20).Background(new SolidColorBrush(Colors.Blue)))
                {
                    button => button.
                        RegisterPropertyChangedCallback(Button.IsPressedProperty, (sender, dp) =>
                        {
                            if (button.IsPressed)
                            {
                                button
                                    .FontSize(50)
                                    .FontFamily(FontFamily.XamlAutoFontFamily)
                                    .FontWeight(new Windows.UI.Text.FontWeight(100))
                                    .Content("CO TO")
                                    .Background(new SolidColorBrush(Colors.White));                                
                            }
                            else
                            {
                                button.FontSize(12);
                                button.Background(new SolidColorBrush(Colors.Red));
                            }
                        }),
                    button => button.
                        RegisterPropertyChangedCallback(Button.IsPointerOverProperty, (sender, dp) =>
                        {
                            if (button.IsPointerOver)
                            {
                                button.Background(new SolidColorBrush(Colors.Blue));
                            }
                            else
                            {
                                button.Background(new SolidColorBrush(Colors.Red));
                            }
                        })
                }))
            }
        };

        public BlankWindow()
        {            

            ExtendsContentIntoTitleBar = true;
           

            Content = new Page
            {
                new Grid
                {
                    new HStack//(e => e.Resources(res))
                    {
                        e => e
                            .HorizontalAlignment(HorizontalAlignment.Center)
                            .VerticalAlignment(VerticalAlignment.Center),

                        new Button()
                            .Assign(out var button)
                            .Content("Standard Button")
                            .Width(300)
                            .Height(300)                                                       
                            .OnClick(button =>
                            {
                                button.Content = "Clicked";
                                text = "HMMM";
                                active = true;
                            })
                            .InvokeOnElement(b =>
                            {
                                b.SetValue(FrameworkElement.NameProperty, "button");
                                b.RegisterPropertyChangedCallback(Button.IsPointerOverProperty, (sender, e) =>
                                {
                                    //stateTrigger.IsActive = (sender as Button).IsPointerOver;
                                });
                            }).Resources(res),

                        new TextBlock()
                            .Text(e => e.Path("text").Source(this))
                    }
                }
                
                //.AddVisualStateGroup(e => e.States(
                                //new VisualState<Button>("")
                                //{
                                //    new Setter { Target = new TargetPropertyPath { Path = new PropertyPath("button.(Button.FontSize)") }, Value = 50 },
                                //    new StateTrigger().Assign(out stateTrigger).InvokeOnElement(s =>
                                //    {
                                //        //button.Background(new SolidColorBrush(Colors.Aqua));
                                //        s.RegisterPropertyChangedCallback(StateTrigger.IsActiveProperty, (s, e) =>
                                //        {

                                //        });
                                //    })
                                //}
                //            ))

            };
        }
    }
}
