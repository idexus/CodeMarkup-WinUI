using System.Collections;

namespace Sharp.UI
{
    /*
    [SharpObject] 
    public partial class ContentPage : Microsoft.Maui.Controls.ContentPage
    { 
        public ContentPage()
        {
            if (HotReload.IsEnabled)
            {
                if (HotReload.BindingContext != null) BindingContext = HotReload.BindingContext;
            }
        }

        public ContentPage(string title) : this()
        {
            this.Title = title;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (HotReload.IsEnabled)
            {
                HotReload.RegisterActive(this);
            }
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            if (HotReload.IsEnabled)
            {
                if (Navigation.NavigationStack.Count > 1) 
                {
                    HotReload.UnregisterActive(this);
                }
            }
        }
    }
    */

}
