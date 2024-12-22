using Microsoft.UI.Xaml;
using System.ComponentModel;

namespace CodeMarkup.WinUI
{
    public interface IThemeSource : INotifyPropertyChanged
    {
        public ResourceDictionary ThemeResources { get; }
    }
}
