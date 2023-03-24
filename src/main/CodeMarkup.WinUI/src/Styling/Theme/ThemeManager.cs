using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.ViewManagement;

namespace CodeMarkup.WinUI.Styling
{
    public class ThemeManager
    {
        static readonly UISettings settings;
        static ThemeManager()
        {
            settings = new UISettings();
            settings.ColorValuesChanged += Settings_ColorValuesChanged;
        }

        private static void Settings_ColorValuesChanged(UISettings sender, object args)
        {
            ThemeChanged?.Invoke();
        }

        internal static event Action ThemeChanged;

        public static void Refresh()
        {
            ThemeChanged?.Invoke();
        }
    }
}
