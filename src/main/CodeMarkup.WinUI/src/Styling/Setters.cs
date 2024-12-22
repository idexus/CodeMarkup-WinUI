using Microsoft.UI.Xaml;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CodeMarkup.WinUI
{
    public partial class Setters<T> : IEnumerable
        where T : FrameworkElement
    {
        readonly static DependencyProperty AttachedStyleInvokeProperty =
            DependencyProperty.RegisterAttached($"AttachedInvokeProperty", typeof(Action<T>), typeof(Setters<T>), new PropertyMetadata(null, OnAttachedInvokeChanged));

        private static void OnAttachedInvokeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var action = e.NewValue as Action<T>;
            if (action != null)
                action?.Invoke(d as T);
        }

        internal SettersContext<T> settersContext = new();

        public Setters() { }

        public Setters(Func<SettersContext<T>,SettersContext<T>> buildSetters)
        {
            buildSetters(settersContext);            
        }

        public Setters(T target, Func<SettersContext<T>, SettersContext<T>> buildSetters)
        {
            settersContext.Target = target;
            buildSetters(settersContext);
        }

        public void Add(Action<T> invokeOnElement)
        {
            if (settersContext.Target != null) throw new NullReferenceException("VisualState setters do not allow to create invokeOnElement action");
            settersContext.XamlSetters.Add(new Setter { Property = AttachedStyleInvokeProperty, Value = invokeOnElement });
        }

        public void Add(Setter setter) => settersContext.XamlSetters.Add(setter);
        IEnumerator IEnumerable.GetEnumerator() => settersContext.XamlSetters.GetEnumerator();
    }
}