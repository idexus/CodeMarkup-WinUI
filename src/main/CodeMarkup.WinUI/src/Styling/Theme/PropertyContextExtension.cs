using System;

namespace CodeMarkup.WinUI.Styling
{
    public static class PropertyContextExtension
    {
        // -- PropertyThemeBuilder --

        public static PropertyThemeBuilder<T> ThemeResource<T>(this PropertyContext<T> self, string key)
            => new PropertyThemeBuilder<T>(self).ThemeResource(key);

    }
}
