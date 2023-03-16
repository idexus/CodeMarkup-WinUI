using System;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media.Imaging;
using Microsoft.UI.Xaml.Controls.Primitives;

namespace ExampleApp
{
    using CodeMarkup.WinUI;
    using CodeMarkup.WinUI.Controls;
    using Microsoft.UI.Xaml;

    public partial class RatingControlPage : ExamplesBasePage
    {
        public RatingControlPage()
        {
            Type = typeof(RatingControl);

            Examples = new()
            {
                new Example
                {
                    new RatingControl()
                        .IsClearEnabled(false)
                        .IsReadOnly(false)
                        .Caption("128 ratings")                        
                        .OnTapped(rc => 
                        {
                            if (rc.IsReadOnly == false)
                            {
                                rc.IsReadOnly = true;
                                rc.Caption("Your rating");
                            }
                        })
                }
                .Title("A RatingControl")
                .SourceText(Sources.SimpleRatingControl),
            };
        }
    }
}

