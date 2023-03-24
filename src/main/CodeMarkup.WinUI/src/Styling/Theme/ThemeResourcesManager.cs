using Microsoft.UI.Xaml;
using System.ComponentModel;
using Windows.UI.ViewManagement;

namespace CodeMarkup.WinUI.Styling
{
    public class ThemeResourcesManager
    {
        public readonly static DependencyProperty UISettingsProperty =
            DependencyProperty.RegisterAttached($"UISettings", typeof(UISettings), typeof(ThemeResourcesManager), new PropertyMetadata(null));

        public FrameworkElement Element { get; set; }


    }
}
