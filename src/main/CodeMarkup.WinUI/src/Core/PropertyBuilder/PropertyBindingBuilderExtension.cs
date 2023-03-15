using Microsoft.UI.Xaml;
using System.Reflection.Metadata;

namespace CodeMarkup.WinUI
{
    public static class PropertyBindingBuilderExtension
    {
        public static PropertyBindingBuilder<bool> Negate(this PropertyBindingBuilder<bool> self)
        {
            return self.Convert<bool>(e => !e).ConvertBack<bool>(e => !e);
        }

        public static PropertyBindingBuilder<T> DictionaryKey<T>(this PropertyBindingBuilder<T> self, string key)
        {
            return self.Convert<object>(value =>
            {
                if (value is ResourceDictionary dictionary)
                {
                    return (T)dictionary[key];
                }
                return default;
            }).ConverterParameter(key);
        }
    }
}
