using System;
using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media.Imaging;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;

namespace ExampleApp
{
    using CodeMarkup.WinUI;
    using CodeMarkup.WinUI.Controls;
    
    [Bindable]
    public partial class PasswordBoxPage : ExamplesBasePage
    {
        public PasswordBoxPage()
        {
            Type = typeof(PasswordBox);

            Examples = new()
            {
                new Example
                {
                    new PasswordBox()
                        .HorizontalAlignment(HorizontalAlignment.Left)
                        .Width(300)
                }
                .Title("Simple password box")
                .SourceText(Sources.Sample1),

                new Example
                {
                    new HStack
                    {
                        new PasswordBox()
                            .Assign(out var passBox)
                            .Width(300)
                            .PasswordChar("#"),

                        new CheckBox()
                            .Margin(20, 0)
                            .Content("Show password")
                            .InvokeOnElement(checkBox =>
                            {
                                passBox.PasswordRevealMode(e => e
                                    .Path("IsChecked").Source(checkBox)
                                    .Convert<bool>(isChecked => isChecked ? PasswordRevealMode.Visible : PasswordRevealMode.Hidden));
                            })
                    }
                }
                .Title("Customized password box")
                .SourceText(Sources.Sample2),
            };
        }
    }
}