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

            #pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
            //InfinateRotation(star1, 5000);
            //InfinateRotation(star2, 7000);
            //InfinateRotation(star3, 9000);
            InfinateScale(playButton, 1000);

            #pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
        }

        
        private async Task InfinateScale(View view, uint length)
        {
            bool always = true;
            while (always)
            {
                await view.ScaleTo(1.1, length);
                await view.ScaleTo(1.0, length);
                view.Rotation = 0;
            }
        }

        private void Play_Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new GamePage());

        }
    }
}