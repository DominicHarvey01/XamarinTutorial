using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NombreMagique.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WelcomePage : ContentPage
    {
        public WelcomePage()
        {
            InitializeComponent();

            //hiding navigation bar
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private void Play_Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new GamePage());

        }
    }
}