﻿using Microsoft.UI.Xaml;
using System;
using System.Collections.Generic;
using CodeOnly.WinUI.Internal;


namespace CodeOnly.WinUI
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

        public Setters(T target, Func<T, T> buildSetters)
        {
            FluentStyling.Setters = this;
            buildSetters?.Invoke(null);
            FluentStyling.Setters = null;
        }
    }
}
