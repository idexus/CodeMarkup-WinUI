using System.Runtime.InteropServices;
using System;
using Microsoft.UI;
using Microsoft.UI.Windowing;
using Windows.Graphics;

namespace ExampleApp
{
    using CodeMarkup.WinUI.Controls;

    internal class MainWindow : Window
    {
        [DllImport("User32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        static extern int GetDpiForWindow(IntPtr hWnd);

        public MainWindow()
        {
            ExtendsContentIntoTitleBar = true;
            Content = new Frame { new MainPage() };

            IntPtr hWnd = WinRT.Interop.WindowNative.GetWindowHandle(this);
            WindowId windowId = Win32Interop.GetWindowIdFromWindow(hWnd);
            AppWindow appWindow = AppWindow.GetFromWindowId(windowId);

            var dpi = GetDpiForWindow(hWnd);
            var size = new SizeInt32
            {
                Width = (int)(1280 * dpi / 96.0),
                Height = (int)(800.0 * dpi / 96.0)
            };
            appWindow.ResizeClient(size);

            //FULL SCREEN
            //appWindow.SetPresenter(AppWindowPresenterKind.FullScreen);
        }
    }
}
