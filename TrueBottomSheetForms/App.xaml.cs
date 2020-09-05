using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TrueBottomSheetForms
{
    public partial class App : Application
    {
        public static Size ScreenSize => new Size(
           DeviceDisplay.MainDisplayInfo.Width / DeviceDisplay.MainDisplayInfo.Density,
           DeviceDisplay.MainDisplayInfo.Height / DeviceDisplay.MainDisplayInfo.Density);

        public App()
        {
            InitializeComponent();
            Device.SetFlags(new string[] { "SwipeView_Experimental" });
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
