using Microsoft.UI.Xaml;
using System.Collections;
using System.Collections.Generic;

namespace CodeMarkup.WinUI.Controls
{
    public interface IUIElementContainer : IEnumerable<UIElement>
    {
        public void Add(UIElement item);
        public DependencyObject Parent { get; }
    }
}
