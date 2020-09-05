using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace TrueBottomSheetForms.Nuget
{
    public class BasePopupPageAnimation : Rg.Plugins.Popup.Interfaces.Animations.IPopupAnimation
    {
        double translationHeight = 0;
        public BasePopupPageAnimation()
        {

        }
        public BasePopupPageAnimation(double translationHeight)
        {
            this.translationHeight = translationHeight;
        }
        public void Preparing(View content, PopupPage page)
        {
            page.IsVisible = false;
            page.BackgroundColor = Color.Black.MultiplyAlpha(0);
            if (content == null) return;

            content.TranslationY = translationHeight;

            _previous = GetPreviousPage();
            if (_previous?.Content == null)
                return;
            _previous.Content.Scale = 1;
        }

        PopupPage _previous;

        Easing EasingIn => Easing.SinIn;
        Easing EasingOut => Easing.SinOut;
        uint Duration => 350U;

        PopupPage GetPreviousPage()
        {
            var stack = PopupNavigation.Instance.PopupStack;

            if (stack.Count > 1)
                return stack[stack.Count - 2];
            else
                return null;
        }

        public void Disposing(View content, PopupPage page)
        {
            page.IsVisible = true;

            if (content == null) return;

            content.TranslationY = 0;
            content.Scale = 1;

            if (_previous?.Content != null)
                _previous.Content.Scale = 1;
        }

        public async Task Appearing(View content, PopupPage page)
        {
            var taskList = new List<Task>();

            if (content != null)
            {
                taskList.Add(content.TranslateTo(content.TranslationX, 0, Duration, EasingIn));
                taskList.Add(page.ColorTo(page.BackgroundColor, Color.Black.MultiplyAlpha(0.2),
                    color => page.BackgroundColor = color, Duration, EasingOut));
            }

            ;

            if (_previous?.Content != null)
            {
                taskList.Add(_previous.Content.ScaleTo(0.96, Duration, EasingOut));
                taskList.Add(_previous.Content.TranslateTo(0, -25, Duration, EasingOut));
                if (content != null)
                    content.Margin = new Thickness(content.Margin.Left,
                        content.Margin.Top,
                        content.Margin.Right,
                        content.Margin.Bottom);

                //taskList.Add(page.ColorTo(page.BackgroundColor, Colors.PopupBlack,
                //color => page.BackgroundColor = color, Duration, EasingOut));
            }

            page.IsVisible = true;

            await Task.WhenAll(taskList);
        }

        public async Task Disappearing(View content, PopupPage page)
        {
            var taskList = new List<Task>();

            if (content != null)
            {
                taskList.Add(content.TranslateTo(content.TranslationX, translationHeight,
                    Duration, EasingOut));
                taskList.Add(page.ColorTo(page.BackgroundColor, Color.Black.MultiplyAlpha(0),
                    color => page.BackgroundColor = color, Duration, EasingOut));
            }

            ;
            if (_previous?.Content != null)
            {
                if (content != null)
                    taskList.Add(_previous.Content.TranslateTo(0, 0, Duration, EasingIn));
                taskList.Add(_previous.Content.ScaleTo(1, Duration, EasingIn));
                //taskList.Add(page.ColorTo(page.BackgroundColor, Color.Transparent,
                //color => page.BackgroundColor = color, Duration, EasingIn));
            }

            await Task.WhenAll(taskList);
        }
    }

}
