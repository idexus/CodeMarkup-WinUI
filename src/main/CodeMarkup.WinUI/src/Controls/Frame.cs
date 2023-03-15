using Microsoft.UI.Xaml;
using System.Collections;
using System.ComponentModel;
using Windows.UI.ViewManagement;

namespace CodeMarkup.WinUI.Controls
{
    [MarkupObject]
    public partial class Frame : Microsoft.UI.Xaml.Controls.Frame, IEnumerable, IThemeSource
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ResourceDictionary ThemeResources => Resources;
        private UISettings _uiSettings;

        public Frame()
        {
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

        // ----- single item container -----

        IEnumerator IEnumerable.GetEnumerator() { yield return this.Content; }
        public void Add(UIElement content) => this.Content = content;
    }
}
