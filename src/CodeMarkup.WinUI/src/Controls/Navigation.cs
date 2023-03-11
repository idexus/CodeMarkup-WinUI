﻿using CodeMarkup.WinUI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Markup;
using System;

namespace CodeMarkup.WinUI.Controls
{
    [CodeMarkup]
    [ContainerProperty(nameof(MenuItems))]
    public partial class NavigationView : Microsoft.UI.Xaml.Controls.NavigationView { }

    [CodeMarkup]
    [ContainerProperty(nameof(MenuItems))]
    public partial class NavigationViewItem : Microsoft.UI.Xaml.Controls.NavigationViewItem { }

    [CodeMarkup]
    [ContainerProperty(nameof(Content))]
    public partial class Frame : Microsoft.UI.Xaml.Controls.Frame { }

    //---

    [CodeMarkup]
    public partial class Pivot : Microsoft.UI.Xaml.Controls.Pivot { }

    [CodeMarkup]
    public partial class TabView : Microsoft.UI.Xaml.Controls.TabView { }

    [CodeMarkup]
    public partial class Page : Microsoft.UI.Xaml.Controls.Page { }

}
