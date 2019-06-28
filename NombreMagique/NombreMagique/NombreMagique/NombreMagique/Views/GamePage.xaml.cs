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
    public partial class GamePage : ContentPage
    {
        int magic_number = 0;
        int user_input = 0;
        const int NB_MAGIQUE_MIN = 0;
        const int NB_MAGIQUE_MAX = 5;

        public GamePage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            magic_number = new Random().Next(NB_MAGIQUE_MIN, NB_MAGIQUE_MAX);
            minMaxLabel.Text = "Entre " + NB_MAGIQUE_MIN + " et " + NB_MAGIQUE_MAX;

        }
   
        private void Btn_Deviner_Clicked(object sender, EventArgs e)
        {
            //DisplayAlert("test", "Le nombre magic est " + magic_number.ToString(), "OK");


            try
            {
                user_input = Int32.Parse(user_nbr_input.Text);
                testChallenge();
            }
            catch (Exception)
            {
                DisplayAlert("Oops", "Vous devez entrer uniquement des chiffres", "OK");
            }


            user_nbr_input.Text = "";
           

        }

        private void testChallenge()
        {
            if (user_input < NB_MAGIQUE_MIN || user_input > NB_MAGIQUE_MAX)
            {
                DisplayAlert("Oops", "Vous devez entrer uniquement un nombre entre "+ NB_MAGIQUE_MIN +" et " + NB_MAGIQUE_MAX, "OK");
                return;
            }
            if (user_input == magic_number)
            {
                //you win
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
                WinAction();// DH - no need to wait.
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
                return;
            }
            else if (user_input < magic_number)
            {
                //magic number is higer
                DisplayAlert("Oops", "Le nombre magic est superieure à " + user_input, "OK");
                return;
            }
            else if (user_input > magic_number)
            {
                //magic number is lower
                DisplayAlert("Almost", "Le nombre magic est inferieure à " + user_input, "OK");
                
                return;
            }
        }
        private async Task WinAction()
        {
            await DisplayAlert("You WIN", "Le nombre magic est exact", "OK");
            await this.Navigation.PopAsync();
        }
    }
}