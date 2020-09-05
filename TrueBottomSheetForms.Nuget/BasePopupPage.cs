using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Rg.Plugins.Popup.Enums;
using Rg.Plugins.Popup.Extensions;
using Xamarin.Forms;

namespace TrueBottomSheetForms.Nuget
{
    public class BasePopupPage : Rg.Plugins.Popup.Pages.PopupPage
    {
        public static BindableProperty VerticalContentOptionsProperty =
           BindableProperty.Create(nameof(VerticalContentOptions),
               typeof(LayoutOptions), typeof(BasePopupPage), LayoutOptions.EndAndExpand);

        public LayoutOptions VerticalContentOptions
        {
            get => (LayoutOptions)GetValue(VerticalContentOptionsProperty);
            set => SetValue(VerticalContentOptionsProperty, value);
        }

        public static BindableProperty DismissableContentProperty =
            BindableProperty.Create(nameof(DismissableContent),
                typeof(View), typeof(BasePopupPage));

        public View DismissableContent
        {
            get => (View)GetValue(DismissableContentProperty);
            set => SetValue(DismissableContentProperty, value);
        }

        public static BindableProperty AnimationTranslationValueProperty =
            BindableProperty.Create(nameof(AnimationTranslationValue),
                typeof(double), typeof(BasePopupPage),
                propertyChanged: (view, oldval, newval)=> {
                    if (oldval == newval) return;
                    if (view is BasePopupPage page && newval is double val)
                        page.Animation = new BasePopupPageAnimation(val);
                });

        public double AnimationTranslationValue
        {
            get => (double)GetValue(AnimationTranslationValueProperty);
            set => SetValue(AnimationTranslationValueProperty, value);
        }

        public static BindableProperty IsPullToCloseEnabledProperty =
           BindableProperty.Create(nameof(IsPullToCloseEnabled),
               typeof(bool), typeof(BasePopupPage), true,
               propertyChanged: (view, oldval, newval) => {
                   if (oldval == newval) return;
                   if (view is BasePopupPage page && page.Content is SwipeView swipeView)
                       if ((bool)newval)
                       {
                           var swipeItem = new SwipeItem()
                           {
                               BackgroundColor = Color.Transparent
                           };
                           swipeItem.Invoked += (args, e) => page.Pop();
                           var swipeItems = new SwipeItems() {
                                 swipeItem
                            };
                           swipeItems.Mode = SwipeMode.Execute;
                           swipeView.TopItems = swipeItems;
                       }
                       else
                       {
                           swipeView.TopItems?.Clear();
                       }
               });

        public bool IsPullToCloseEnabled
        {
            get => (bool)GetValue(IsPullToCloseEnabledProperty);
            set => SetValue(IsPullToCloseEnabledProperty, value);
        }

        public BasePopupPage()
        {

            Animation = new BasePopupPageAnimation();
            IsAnimationEnabled = true;
            CloseWhenBackgroundIsClicked = true;
            SystemPaddingSides = PaddingSide.All;
            HasSystemPadding = true;
            HasKeyboardOffset = false;

            var swipeItem = new SwipeItem()
            {
                BackgroundColor = Color.Transparent
            };
            swipeItem.Invoked += (args, e) => Pop();
            var swipeItems = new SwipeItems() {
                swipeItem
            };
            swipeItems.Mode = SwipeMode.Execute;

            Content = new SwipeView()
            {
                TopItems = swipeItems,
                BackgroundColor = Color.Transparent,

                Content = new ContentView()
                .Bind(ContentView.ContentProperty, DismissableContentProperty.PropertyName, source: this)
            }.Bind(ContentView.VerticalOptionsProperty, VerticalContentOptionsProperty.PropertyName, source:this);
        }

         void Pop()
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                await Application.Current.MainPage.Navigation.PopPopupAsync();
            });
        }
    }
}
