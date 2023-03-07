using Microsoft.UI.Xaml;
using System;


namespace CodeOnly.WinUI.Core
{
    public sealed class PropertyThemeBuilder<T> : IPropertyBuilder<T>
    {
        public PropertyContext<T> Context { get; set; }

        T newValue;
        T defaultValue;
        Func<PropertyContext<T>, IPropertyBuilder<T>> defaultConfigure;

        bool isSet;
        bool defaultIsSet;
        bool buildValue;

        public PropertyThemeBuilder(PropertyContext<T> context)
        {
            Context = context;
        }

        public bool Build()
        {
            if (buildValue)
                Context.Element.SetValueOrAddSetter(Context.Property, newValue);
            else if (!isSet)
            {
                if (defaultIsSet)
                {
                    if (defaultConfigure != null)
                        isSet = defaultConfigure(Context).Build();
                    else
                        Context.Element.SetValueOrAddSetter(Context.Property, defaultValue);
                }

            }
            return isSet;
        }

        // Default

        public PropertyThemeBuilder<T> Default(T value)
        {
            if (!defaultIsSet)
            {
                this.defaultValue = value;
                this.defaultIsSet = true;
            }
            return this;
        }

        public PropertyThemeBuilder<T> Default(Func<PropertyContext<T>, IPropertyBuilder<T>> configure)
        {
            if (!defaultIsSet)
            {
                this.defaultConfigure = configure;
                this.defaultIsSet = true;
            }
            return this;
        }

        // OnLight

        public PropertyThemeBuilder<T> OnLight(T value)
        {
            if (!isSet && Application.Current.RequestedTheme == ApplicationTheme.Light)
            {
                newValue = value;
                buildValue = true;
                isSet = true;
            }
            return this;
        }

        public PropertyThemeBuilder<T> OnLight(Func<PropertyContext<T>, IPropertyBuilder<T>> configure)
        {
            if (!isSet && Application.Current.RequestedTheme == ApplicationTheme.Light)
                isSet = configure(Context).Build();
            return this;
        }

        // OnDark

        public PropertyThemeBuilder<T> OnDark(T value)
        {
            if (!isSet && Application.Current.RequestedTheme == ApplicationTheme.Dark)
            {
                newValue = value;
                buildValue = true;
                isSet = true;
            }
            return this;
        }

        public PropertyThemeBuilder<T> OnDark(Func<PropertyContext<T>, IPropertyBuilder<T>> configure)
        {
            if (!isSet && Application.Current.RequestedTheme == ApplicationTheme.Dark)
                isSet = configure(Context).Build();
            return this;
        }
    }
}
