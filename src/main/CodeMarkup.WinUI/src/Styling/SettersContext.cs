using Microsoft.UI.Xaml;
using System;
using System.Collections.Generic;
using CodeMarkup.WinUI.Internal;


namespace CodeMarkup.WinUI.Styling
{
    public class SettersContext<T> 
        where T : DependencyObject
	{
        public List<SetterBase> XamlSetters = new();
        public FrameworkElement Target { get; set; } = null;
    }
}
