using Microsoft.UI.Xaml;
using System;

namespace CodeMarkup.WinUI.HotReload
{
    public static class HotReloadContext
    {
        public static Action<FrameworkElement> Handler { get; set; }
    }
}
