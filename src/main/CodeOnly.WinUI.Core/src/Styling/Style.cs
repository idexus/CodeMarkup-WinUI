using CodeOnly.WinUI.Core.Internal;
using Microsoft.UI.Xaml;
using System;
using System.Collections;
using System.Linq;

namespace CodeOnly.WinUI.Core
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

        Microsoft.UI.Xaml.Style xamlStyle;
        public static implicit operator Style(Style<T> style) => style.xamlStyle;

        public Style()
        {
            this.xamlStyle = new Microsoft.UI.Xaml.Style(typeof(T));
        }

        public Style(Style basedOn) : this()
        {
            foreach (var setter in basedOn.Setters) this.xamlStyle.Setters.Add(setter);
        }

        public Style(Func<T,T> buildSetters) : this()
        {
            BuildSetters(buildSetters);
        }

        public Style(Style<T> basedOn, Func<T, T> buildSetters) : this(basedOn)
        {
            BuildSetters(buildSetters);
        }

        void BuildSetters(Func<T,T> buildSetters)
        {
            FluentStyling.Setters = xamlStyle.Setters;
            buildSetters?.Invoke(null);
            FluentStyling.Setters = null;        
        }

        public void Add(Action<T> invokeOnElement)
        {
            xamlStyle.Setters.Add(new Setter { Property = AttachedStyleInvokeProperty, Value = invokeOnElement });
        }

        public void Add(Setter setter) => this.xamlStyle.Setters.Add(setter);

        //public void Add(TriggerBase trigger) => this.mauiStyle.Triggers.Add(trigger);

        //public void Add(VisualStateGroup group)
        //{
        //    mauiStyle.GetVisualStateGroupList().Add(group);
        //}

        //public void Add(VisualState visualState)
        //{
        //    var visualStateGroupList = mauiStyle.GetVisualStateGroupList();
        //    visualStateGroupList.GetCommonStatesVisualStateGroup().States.Add(visualState);
        //}

        IEnumerator IEnumerable.GetEnumerator() => xamlStyle.Setters.GetEnumerator();
    }
    
}