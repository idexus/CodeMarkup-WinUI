using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Media.Animation;
using System;
using System.Collections;

namespace CodeMarkup.WinUI
{
    public partial class VisualState : IEnumerable
    {
        public const string CommonStates = "CommonStates";

        //------ const -------

        public class Control
        {
            public const string Normal = "Normal";
            public const string Disabled = "Disabled";
            public const string Focused = "Focused";
            public const string PointerOver = "PointerOver";
        }

        public class Button : Control
        {
            public const string Pressed = "Pressed";
        }

        Microsoft.UI.Xaml.VisualState xamlVisualState;
        public static implicit operator Microsoft.UI.Xaml.VisualState(VisualState visualState) => visualState.xamlVisualState;

        IEnumerator IEnumerable.GetEnumerator() => xamlVisualState.Setters.GetEnumerator();

        public void Add(SetterBase setter) => this.xamlVisualState.Setters.Add(setter);
        public void Add(StateTriggerBase triggerBase) => this.xamlVisualState.StateTriggers.Add(triggerBase);
        public void Add(Storyboard storyboard) => this.xamlVisualState.Storyboard = storyboard;

        public void Add<Q>(Setters<Q> setters)
            where Q : FrameworkElement
        {
            if (setters.settersContext.Target == null) throw new NullReferenceException("VisualState setters must have target defined");
            foreach (var setter in setters.settersContext.XamlSetters)
                this.xamlVisualState.Setters.Add(setter);            
        }

        public VisualState(string name = null)
        {
            this.xamlVisualState = new Microsoft.UI.Xaml.VisualState();
            if (name != null) this.xamlVisualState.SetValue(FrameworkElement.NameProperty, name);
        }
    }
}