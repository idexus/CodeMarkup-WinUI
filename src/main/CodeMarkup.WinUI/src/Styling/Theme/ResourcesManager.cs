using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.ViewManagement;

namespace CodeMarkup.WinUI.Styling
{
    public class ResourcesManager
    {
        static readonly UISettings settings;
        static ResourcesManager()
        {
            settings = new UISettings();
            settings.ColorValuesChanged += settings_ColorValuesChanged;
        }

        private static void settings_ColorValuesChanged(UISettings sender, object args)
        {
            ThemeChanged?.Invoke();
        }

        internal static event Action ThemeChanged;

        public static void UpdateTheme()
        {
            ThemeChanged?.Invoke();
        }
    }
}
