using Microsoft.UI.Xaml;
using System;
using System.Collections.Generic;
using CodeOnly.WinUI.Core.Internal;


namespace CodeOnly.WinUI.Core
{
    public class Setters<T> : List<SetterBase>
        where T : UIElement
	{
        public Setters(Func<T,T> buildSetters)
        {
            FluentStyling.Setters = this;
            buildSetters?.Invoke(null);
            FluentStyling.Setters = null;            
        }
    }
}
