using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using CodeOnly.WinUI;

namespace ExampleApp
{
    using CodeOnly.WinUI;
    using Microsoft.UI;
    using Microsoft.UI.Xaml.Media;
    using Microsoft.UI.Xaml.Media.Animation;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    internal class BlankWindowPage : Window
    {
        public BlankWindowPage()
        {            
            ExtendsContentIntoTitleBar = true;
            Content = new CodePage();
        }
    }
}
