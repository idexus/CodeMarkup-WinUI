using Microsoft.UI.Xaml;
using System.ComponentModel;

namespace CodeMarkup.WinUI.Controls
{
    public interface IThemeSource : INotifyPropertyChanged
    {
        public ResourceDictionary ThemeResources { get; }
    }
}
