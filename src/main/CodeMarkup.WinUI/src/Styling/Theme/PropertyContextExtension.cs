using System;

namespace CodeMarkup.WinUI.Styling
{
    public static class PropertyContextExtension
    {
        // -- PropertyThemeBuilder --

        public static PropertyThemeBuilder<T> ResourceKey<T>(this PropertyContext<T> self, string key)
            => new PropertyThemeBuilder<T>(self).ResourceKey(key);

    }
}
