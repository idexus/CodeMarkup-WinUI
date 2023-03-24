using Microsoft.UI.Xaml;
using System.ComponentModel;
using Windows.UI.ViewManagement;

namespace CodeMarkup.WinUI.Styling
{
    public class AttachedSettings
    {
        public readonly static DependencyProperty UISettingsProperty =
            DependencyProperty.RegisterAttached($"UISettings", typeof(UISettings), typeof(AttachedSettings), new PropertyMetadata(null));

    }
}
