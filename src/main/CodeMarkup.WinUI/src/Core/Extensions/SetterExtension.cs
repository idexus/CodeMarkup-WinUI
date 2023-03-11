using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System.Collections.Generic;

namespace CodeMarkup.WinUI
{

    public static partial class SetterExtension
    {
        public static Setter Target(this Setter self, object target, string path)
        {
            self.Target = new TargetPropertyPath { Path = new PropertyPath(path), Target = target };
            return self;
        }

        public static Setter OnDarkValue(this Setter self, object value)
        {
            if (Application.Current.RequestedTheme == ApplicationTheme.Dark) self.Value = value;
            return self;
        }

        public static Setter OnLightValue(this Setter self, object value)
        {
            if (Application.Current.RequestedTheme == ApplicationTheme.Light) self.Value = value;
            return self;
        }
    }
}