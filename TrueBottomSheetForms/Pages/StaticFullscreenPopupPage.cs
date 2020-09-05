using System;
using TrueBottomSheetForms.Nuget;
using Xamarin.Forms;
using Xamarin.Forms.PancakeView;

namespace TrueBottomSheetForms.Pages
{
    public class StaticFullscreenPopupPage : BasePopupPage
    {
        public StaticFullscreenPopupPage()
        {
            AnimationTranslationValue = App.ScreenSize.Height;

            var goNextButton = new Button
            {
                Text = "go deeper",
                VerticalOptions = LayoutOptions.EndAndExpand,
            };
            goNextButton.Clicked += (e, args)=> NavigationExtension.PopupPush(new StaticFullscreenPopupPage());
            VerticalContentOptions = LayoutOptions.FillAndExpand;
            DismissableContent = new PancakeView
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.White,
                CornerRadius = new CornerRadius(10,10,0,0),
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
                        new Label
                        {
                            Text = "Empty",
                            VerticalOptions = LayoutOptions.FillAndExpand,
                            HorizontalOptions = LayoutOptions.CenterAndExpand,
                            TextColor = Color.Black
                        },
                        goNextButton
                    }
                }
            };
        }
    }
}

