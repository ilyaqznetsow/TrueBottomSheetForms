using System;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;

namespace TrueBottomSheetForms
{
    internal static class NavigationExtension
    {
        internal static void PopupPush(PopupPage page)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
               await Application.Current.MainPage.Navigation.PushPopupAsync(page);
            });
        }
    }
}
