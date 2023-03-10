using System;

namespace CodeOnly.WinUI
{
    public static class PropertyContextExtension
    {
        // --- PropertyBindingBuilder ---

        public static PropertyBindingBuilder<T> Path<T>(this PropertyContext<T> self, string path)
            => new PropertyBindingBuilder<T>(self).Path(path);

     
        // -- PropertyThemeBuilder --

        public static PropertyThemeBuilder<T> OnLight<T>(this PropertyContext<T> self, T value)
            => new PropertyThemeBuilder<T>(self).OnLight(value);

        public static PropertyThemeBuilder<T> OnLight<T>(this PropertyContext<T> self, Func<PropertyContext<T>, IPropertyBuilder<T>> configure)
            => new PropertyThemeBuilder<T>(self).OnLight(configure);

        public static PropertyThemeBuilder<T> OnDark<T>(this PropertyContext<T> self, T value)
            => new PropertyThemeBuilder<T>(self).OnDark(value);

        public static PropertyThemeBuilder<T> OnDark<T>(this PropertyContext<T> self, Func<PropertyContext<T>, IPropertyBuilder<T>> configure)
            => new PropertyThemeBuilder<T>(self).OnDark(configure);

    }
}
