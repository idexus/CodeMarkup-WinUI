using Microsoft.UI.Xaml;
using System.Collections;
using System.ComponentModel;
using Windows.UI.ViewManagement;

namespace CodeMarkup.WinUI.Controls
{
    [MarkupObject]
    public partial class Frame : Microsoft.UI.Xaml.Controls.Frame, IEnumerable
    { 
        // ----- single item container -----

        IEnumerator IEnumerable.GetEnumerator() { yield return this.Content; }
        public void Add(UIElement content) => this.Content = content;
    }
}
