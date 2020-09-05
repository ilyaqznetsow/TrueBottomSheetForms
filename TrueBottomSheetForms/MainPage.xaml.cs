using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrueBottomSheetForms.Pages;
using Xamarin.Forms;

namespace TrueBottomSheetForms
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        void staticPush_Clicked(System.Object sender, System.EventArgs e)
        {
            NavigationExtension.PopupPush(new StaticFullscreenPopupPage());
        }

        void bottomPush_Clicked(System.Object sender, System.EventArgs e)
        {
            NavigationExtension.PopupPush(new StaticFullscreenPopupPage()
            { VerticalContentOptions = LayoutOptions.EndAndExpand });
        }

        void collectionPush_Clicked(System.Object sender, System.EventArgs e)
        {
            NavigationExtension.PopupPush(new CollectionViewPopupPage()
            { VerticalContentOptions = LayoutOptions.EndAndExpand });
        }
    }
}
