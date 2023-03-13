using Microsoft.UI.Xaml;
using System.Collections;

namespace CodeMarkup.WinUI.Controls
{
    [MarkupObject]
    [ContainerProperty(nameof(MenuItems))]
    public partial class NavigationView : Microsoft.UI.Xaml.Controls.NavigationView { }

    [MarkupObject]
    [ContainerProperty(nameof(MenuItems))]
    public partial class NavigationViewItem : Microsoft.UI.Xaml.Controls.NavigationViewItem { }

    [MarkupObject]
    public partial class Frame : Microsoft.UI.Xaml.Controls.Frame, IEnumerable
    {
        // ----- single item container -----

        IEnumerator IEnumerable.GetEnumerator() { yield return this.Content; }
        public void Add(UIElement content) => this.Content = content;
    }
}
