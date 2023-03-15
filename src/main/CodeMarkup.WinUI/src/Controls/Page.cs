using CodeMarkup.WinUI.HotReload;
using Microsoft.UI.Xaml;
using System.ComponentModel;
using Windows.UI.ViewManagement;

namespace CodeMarkup.WinUI.Controls
{
    public interface IThemeResources
    {
        public ResourceDictionary ThemeResources { get; }
    }

    [MarkupObject]
    [ContainerProperty(nameof(Content))]
    public partial class Page : Microsoft.UI.Xaml.Controls.Page, INotifyPropertyChanged, IThemeResources
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ResourceDictionary ThemeResources => Resources;
        private UISettings _uiSettings;

        public Page()
        {
            HotReloadContext.Handler?.Invoke(this);

            _uiSettings = new UISettings();
            _uiSettings.ColorValuesChanged += _uiSettings_ColorValuesChangedAsync;
        }

        void _uiSettings_ColorValuesChangedAsync(UISettings sender, object args)
        {
            this.DispatcherQueue.TryEnqueue(() =>
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ThemeResources)));
            });
        }
    }
}
