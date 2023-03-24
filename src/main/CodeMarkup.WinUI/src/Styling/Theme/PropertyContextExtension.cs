using System;

namespace CodeMarkup.WinUI.Styling
{
    public static class PropertyContextExtension
    {
        // -- PropertyThemeBuilder --

        public static PropertyResourceBuilder<T> ResourceKey<T>(this PropertyContext<T> self, string key)
            => new PropertyResourceBuilder<T>(self).ResourceKey(key);

    }
}
