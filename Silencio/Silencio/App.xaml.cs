using Silencio.Views;
using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Silencio
{
    public partial class App : Application
    {
        public static MobileServiceClient MobileService = new MobileServiceClient("https://silencio.azurewebsites.net");

        public App()
        {
            InitializeComponent();
            if (!string.IsNullOrEmpty(Settings.UserId))
                Current.MainPage = new NavigationPage(new Views.InstrumentPage());
            else
                Current.MainPage = new NavigationPage(new Views.SignInPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
