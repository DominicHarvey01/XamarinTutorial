using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PizzApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage();

            var navigationPage = new NavigationPage(new MainPage());
            navigationPage.BarBackgroundColor = Color.FromHex("#1abbd4");
            MainPage = navigationPage;
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
