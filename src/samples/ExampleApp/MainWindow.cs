﻿using Microsoft.UI.Xaml;

namespace ExampleApp
{
    internal class MainWindow : Window
    {
        public MainWindow()
        {            
            ExtendsContentIntoTitleBar = true;
            Content = new MainPage();
        }
    }
}