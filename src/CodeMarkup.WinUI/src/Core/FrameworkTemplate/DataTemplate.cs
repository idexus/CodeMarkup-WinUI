﻿using Microsoft.UI.Xaml;

namespace CodeMarkup.WinUI
{
    public class DataTemplate<TRoot> : FrameworkTemplate<DataTemplate, TRoot>
        where TRoot : FrameworkElement, IFrameworkTemplate, new()
    {

    }
}