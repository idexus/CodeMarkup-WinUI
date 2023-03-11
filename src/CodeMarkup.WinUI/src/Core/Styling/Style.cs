using CodeMarkup.WinUI.Internal;
using Microsoft.UI.Xaml;
using System;
using System.Collections;
using System.Linq;

namespace CodeMarkup.WinUI
{
    
    public partial class Style<T> : IEnumerable
        where T : FrameworkElement
    {
        readonly static DependencyProperty AttachedStyleInvokeProperty =
            DependencyProperty.RegisterAttached($"{nameof(Style<T>)}.AttachedInvokeProperty", typeof(Action<T>), typeof(Style<T>), new PropertyMetadata(null, OnAttachedInvokeChanged));

        private static void OnAttachedInvokeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var action = e.NewValue as Action<T>;
            if (action != null)
                action?.Invoke(d as T);
        }

        readonly Microsoft.UI.Xaml.Style xamlStyle;
        public static implicit operator Style(Style<T> style) => style.xamlStyle;

        public Style()
        {
            this.xamlStyle = new Microsoft.UI.Xaml.Style(typeof(T));
        }

        public Style(Style<T> basedOn) : this()
        {
            foreach (var setter in basedOn.xamlStyle.Setters) this.xamlStyle.Setters.Add(setter);
        }

        public Style(Func<SettersContext<T>,SettersContext<T>> buildSetters) : this()
        {
            BuildSetters(buildSetters);
        }

        public Style(Style<T> basedOn, Func<SettersContext<T>, SettersContext<T>> buildSetters) : this(basedOn)
        {
            BuildSetters(buildSetters);
        }

        public Style(T target, Func<SettersContext<T>, SettersContext<T>> buildSetters) : this()
        {
            BuildSetters(buildSetters, target);
        }

        public Style(Style<T> basedOn, T target, Func<SettersContext<T>, SettersContext<T>> buildSetters) : this(basedOn)
        {
            BuildSetters(buildSetters, target);
        }

        void BuildSetters(Func<SettersContext<T>, SettersContext<T>> buildSetters, FrameworkElement target = null)
        {
            var settersContext = new SettersContext<T> { Target = target };
            buildSetters(settersContext);
            foreach (var setter in settersContext.XamlSetters)
                this.xamlStyle.Setters.Add(setter);
        }

        public void Add(Action<T> invokeOnElement)
        {
            xamlStyle.Setters.Add(new Setter { Property = AttachedStyleInvokeProperty, Value = invokeOnElement });
        }

        public void Add(Setter setter) => this.xamlStyle.Setters.Add(setter);
        
        public void Add(Setters<T> setters)
        {
            foreach(var setter in setters.settersContext.XamlSetters)
                this.xamlStyle.Setters.Add(setter);
        }

        IEnumerator IEnumerable.GetEnumerator() => xamlStyle.Setters.GetEnumerator();
    }
    
}