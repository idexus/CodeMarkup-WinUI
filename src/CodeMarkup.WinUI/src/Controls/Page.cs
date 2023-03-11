using CodeMarkup.WinUI.HotReload;

namespace CodeMarkup.WinUI.Controls
{
    [CodeMarkup]
    public partial class Page : Microsoft.UI.Xaml.Controls.Page
    {
        public Page()
        {
            HotReloadContext.Handler?.Invoke(this);
        }

        //protected override void OnAppearing()
        //{
        //    base.OnAppearing();
        //    if (HotReload.IsEnabled)
        //    {
        //        HotReload.RegisterActive(this);
        //    }
        //}

        //protected override void OnDisappearing()
        //{
        //    base.OnDisappearing();
        //    if (HotReload.IsEnabled)
        //    {
        //        if (Navigation.NavigationStack.Count > 1)
        //        {
        //            HotReload.UnregisterActive(this);
        //        }
        //    }
        //}
    }
}
