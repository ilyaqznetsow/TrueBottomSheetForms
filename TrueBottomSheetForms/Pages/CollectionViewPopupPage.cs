using System;
using System.Collections.Generic;
using TrueBottomSheetForms.Nuget;
using Xamarin.Forms;
using Xamarin.Forms.PancakeView;

namespace TrueBottomSheetForms.Pages
{
    public class CollectionViewPopupPage: BasePopupPage
    {
        public CollectionViewPopupPage()
        {
            AnimationTranslationValue = App.ScreenSize.Height;

            VerticalContentOptions = LayoutOptions.EndAndExpand;

            var collectionView = new CollectionView
            {
                VerticalOptions = LayoutOptions.Fill,
                HeightRequest = 300,
                ItemsLayout =
                          new LinearItemsLayout(ItemsLayoutOrientation.Vertical)
                          {
                              ItemSpacing = 5
                          },
                Header = new ContentView {
                    Content = new Label { Text = "Header" },
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Center,
                },
                Footer = new ContentView
                {
                    Content = new Label { Text = "Footer" },
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Center,
                },
                ItemTemplate = new DataTemplate(() => new Frame
                {
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Center,
                    HasShadow = false,
                    HeightRequest = 30,
                    WidthRequest = 30,
                    CornerRadius = 15,
                    BackgroundColor = Color.LightGray,
                    Content = new Label
                    {
                        Text = "Sample",
                        TextColor = Color.White,
                        VerticalOptions = LayoutOptions.Center,
                        HorizontalOptions = LayoutOptions.Center
                    }
                }),
                ItemsSource = new List<object> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 }
            };

            collectionView.Scrolled += (e, args) => this.IsPullToCloseEnabled = !(args.VerticalOffset > 0);

            DismissableContent = new PancakeView
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.White,
                CornerRadius = new CornerRadius(10, 10, 0, 0),
                Content = new StackLayout
                {
                    VerticalOptions = LayoutOptions.Fill,
                    BackgroundColor = Color.White,
                    Padding = 7,
                    Spacing = 10,
                    Children =
                    {
                        new BoxView
                        {
                            Color = Color.LightGray,
                            WidthRequest = 40,
                            HeightRequest = 4,
                            CornerRadius = 2,
                            HorizontalOptions =  LayoutOptions.Center
                        },
                        new Label
                        {
                            Text="Pull to close",
                            LineBreakMode = LineBreakMode.NoWrap,
                            HorizontalOptions =  LayoutOptions.Center,
                            TextColor = Color.Black
                        },
                        collectionView
                    }
                }
            };
        }
    }
}
