using Microsoft.UI.Xaml;
using System.ComponentModel;
using Windows.UI.ViewManagement;

namespace CodeMarkup.WinUI.Styling
{
    public class ThemeResourcesManager : INotifyPropertyChanged
    {
        public readonly static DependencyProperty DefaultManagerProperty =
            DependencyProperty.RegisterAttached($"DefaultManager", typeof(ThemeResourcesManager), typeof(ThemeResourcesManager), new PropertyMetadata(null));

        public event PropertyChangedEventHandler PropertyChanged;

        public FrameworkElement Element { get; set; }
        public ResourceDictionary ThemeResources => Element.Resources;

        UISettings _uiSettings;
        public ThemeResourcesManager()
        {
            _uiSettings = new UISettings();
            _uiSettings.ColorValuesChanged += _uiSettings_ColorValuesChangedAsync;
        }

        void _uiSettings_ColorValuesChangedAsync(UISettings sender, object args)
        {
            this.Element?.DispatcherQueue.TryEnqueue(() =>
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ThemeResources)));
            });
        }
    }
}
