using CodeOnly.WinUI.Core.Internal;
using Microsoft.UI.Xaml;
using System;
using System.Collections;

namespace CodeOnly.WinUI.Core
{
    
    public partial class VisualState<T> : IEnumerable
        where T : FrameworkElement
    {
        readonly static DependencyProperty AttachedVisualStateInvokeProperty =
            DependencyProperty.RegisterAttached($"{nameof(VisualState<T>)}.AttachedInvokeProperty", typeof(Action<T>), typeof(VisualState<T>), new PropertyMetadata(null, OnAttachedInvokeChanged));

        private static void OnAttachedInvokeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var action = e.NewValue as Action<T>;
            if (action != null)
                action?.Invoke(d as T);
        }

        VisualState xamlVisualState;
        public static implicit operator VisualState(VisualState<T> visualState) => visualState.xamlVisualState;

        IEnumerator IEnumerable.GetEnumerator() => xamlVisualState.Setters.GetEnumerator();

        public void Add(SetterBase setter) => this.xamlVisualState.Setters.Add(setter);
        public void Add(StateTriggerBase triggerBase) => this.xamlVisualState.StateTriggers.Add(triggerBase);
        public void Add(Setters<T> setters)
        {
            foreach (var setter in setters)
                xamlVisualState.Setters.Add(setter);
        }

        public void Add(Action<T> invokeOnElement)
        {
            xamlVisualState.Setters.Add(new Setter { Property = AttachedVisualStateInvokeProperty, Value = invokeOnElement });
        }

        public VisualState(string name = null)
        {
            this.xamlVisualState = new VisualState();
            if (name != null) this.xamlVisualState.SetValue(FrameworkElement.NameProperty, name);
        }

        public VisualState(string name, Func<T, T> buildSetters) : this(name)
        {
            ConfigureSetters(buildSetters);
        }

        void ConfigureSetters(Func<T, T> styleElement)
        {
            FluentStyling.Setters = xamlVisualState.Setters;
            styleElement?.Invoke(null);
            FluentStyling.Setters = null;
        }
    }
}

