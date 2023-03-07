﻿using System;
using System.Collections;

namespace CodeOnly.WinUI.Core
{
    /*
    public partial class Style<T> : IEnumerable
        where T : BindableObject
    {
        readonly static BindableProperty AttachedStyleInvokeProperty =
            BindableProperty.CreateAttached($"{nameof(Style<T>)}.AttachedInvokeProperty", typeof(Action<T>), typeof(Style<T>), null, propertyChanged: OnAttachedInvokeChanged);

        static void OnAttachedInvokeChanged(BindableObject obj, object oldValue, object newValue)
        {
            var action = newValue as Action<T>;
            if (obj is VisualElement visualElement && visualElement.Handler != null)
                action?.Invoke(obj as T);
        }

        Microsoft.Maui.Controls.Style mauiStyle;
        public static implicit operator Style(Style<T> style) => style.mauiStyle;

        public Style()
        {
            this.mauiStyle = new Microsoft.Maui.Controls.Style(typeof(T));
        }

        public Style(Style basedOn) : this()
        {
            foreach (var setter in basedOn.Setters) this.mauiStyle.Setters.Add(setter);
            foreach (var trigger in basedOn.Triggers) this.mauiStyle.Triggers.Add(trigger);
        }

        public Style(bool applyToDerivedTypes) : this()
        {
            mauiStyle.ApplyToDerivedTypes = applyToDerivedTypes;
        }

        public Style(Func<T,T> buildSetters) : this()
        {
            BuildSetters(buildSetters);
        }

        public Style(bool applyToDerivedTypes, Func<T, T> styleElement) : this()
        {
            mauiStyle.ApplyToDerivedTypes = applyToDerivedTypes;
            BuildSetters(styleElement);
        }

        public Style(Style<T> basedOn, bool applyToDerivedTypes) : this(basedOn)
        {
            mauiStyle.ApplyToDerivedTypes = applyToDerivedTypes;
        }

        public Style(Style<T> basedOn, Func<T, T> buildSetters) : this(basedOn)
        {
            BuildSetters(buildSetters);
        }

        public Style(Style<T> basedOn, bool applyToDerivedTypes, Func<T, T> styleElement) : this(basedOn)
        {
            mauiStyle.ApplyToDerivedTypes = applyToDerivedTypes;
            BuildSetters(styleElement);
        }

        void BuildSetters(Func<T,T> buildSetters)
        {
            FluentStyling.Setters = mauiStyle.Setters;
            buildSetters?.Invoke(null);
            FluentStyling.Setters = null;        
        }

        public void Add(Action<T> invokeOnElement)
        {
            mauiStyle.Setters.Add(new Setter { Property = AttachedStyleInvokeProperty, Value = invokeOnElement });
        }

        public void Add(Setter setter) => this.mauiStyle.Setters.Add(setter);
        public void Add(TriggerBase trigger) => this.mauiStyle.Triggers.Add(trigger);

        public void Add(VisualStateGroup group)
        {
            mauiStyle.GetVisualStateGroupList().Add(group);
        }

        public void Add(VisualState visualState)
        {
            var visualStateGroupList = mauiStyle.GetVisualStateGroupList();
            visualStateGroupList.GetCommonStatesVisualStateGroup().States.Add(visualState);
        }

        IEnumerator IEnumerable.GetEnumerator() => mauiStyle.Setters.GetEnumerator();
    }
    */
}