# Overview

__CodeMarkup for WinUI__ enables you to build user interfaces declaratively in C# code using fluent methods. With this library, you can create interfaces without the need for XAML.

<img src="https://github.com/idexus/CodeMarkup.WinUI/raw/main/doc/assets/gallery.jpg" alt="Hot Reload Support" width="800" border="0" />

# Example Page

```cs
using Windows.UI;
using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Data;

namespace ExampleApp
{
    using CodeMarkup.WinUI;

    [Bindable]
    public partial class HomePage : Page
    {
        int count = 0;

        public HomePage()
        {
            this.Resources = new()
            {
                new ThemeValue<Color> { Key = "HeaderColor", Light = Colors.Navy, Dark = Colors.Aqua }
            };

            this.VerticalAlignment = VerticalAlignment.Center;

            Content = new StackPanel
            {
                new TextBlock()
                    .FontSize(45)
                    .Text("Code Markup for WinUI")
                    .TextAlignment(TextAlignment.Center)
                    .Foreground(e => e.ResourceKey("HeaderColor").Source(this)),

                new TextBlock()
                    .FontSize(20)
                    .Text("Welcome to the Quick Samples Gallery")
                    .TextAlignment(TextAlignment.Center),

                new Button()
                    .Content("Click me")
                    .Margin(0,35,0,15)
                    .FontSize(20)
                    .HorizontalAlignment(HorizontalAlignment.Center)
                    .OnClick(button =>
                    {
                        count++;
                        button.Content = $"Clicked {count} ";
                        button.Content += count == 1 ? "time" : "times";
                    })
            };
        }
    }
}
```

# Nuget

- [CodeMarkup.WinUI](https://www.nuget.org/packages/CodeMarkup.WinUI)

# In Your Project

__CodeMarkup for WinUI__ replaces some standard WinUI classes by subclassing them and adding new constructors and `IEnumerable` interface implementation. To use CodeMarkup controls in your projects, you need to include the `using CodeMarkup.WinUI` statement inside your app namespace.

```cs
using Windows.UI;
using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Data;

namespace ExampleApp;
using CodeMarkup.WinUI;

...
```

Or:

```cs
using Windows.UI;
using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Data;

namespace ExampleApp
{
    using CodeMarkup.WinUI;
    ...
}
```

# Disclaimer

__CodeMarkup for WinUI__ is a proof of concept. There is no official support. Use at your own risk.

# License 

[The MIT License](LICENSE), Copyright (c) 2023 Pawel Krzywdzinski
