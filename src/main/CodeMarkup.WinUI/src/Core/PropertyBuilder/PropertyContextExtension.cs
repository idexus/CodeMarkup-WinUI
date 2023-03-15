using System;

namespace CodeMarkup.WinUI
{
    public static class PropertyContextExtension
    {
        // --- PropertyBindingBuilder ---

        public static PropertyBindingBuilder<T> Path<T>(this PropertyContext<T> self, string path)
            => new PropertyBindingBuilder<T>(self).Path(path);

     
        // -- PropertyThemeBuilder --

        public static PropertyThemeBuilder<T> ThemeResource<T>(this PropertyContext<T> self, string key)
            => new PropertyThemeBuilder<T>(self).ThemeResource(key);

    }
}
