using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace lelab.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TabAvion : ContentPage
    {
        uint length = 800;

        public TabAvion()
        {
            InitializeComponent();
            AvionImage.Opacity = 0;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            AvionImage.TranslationX = -250;
            AvionImage.TranslationY = -150;
            AvionImage.Rotation = 45;
            AvionImage.Scale = 0.7;
            AvionImage.Opacity = 0;

            

            // all executed in parallels
           /* AvionImage.FadeTo(1, 100);
            AvionImage.TranslateTo(0, 0, length, Easing.SinOut);
            AvionImage.RotateTo(0, length, Easing.SinOut);            
            AvionImage.ScaleTo(1, length, Easing.SinOut);*/


            /**
             * ATERNATIVE #1:  To do itin serial
             */
            /*AvionImage.RotateTo(0, length, Easing.SinOut).ContinueWith((arg) =>
            {
                AvionImage.ScaleTo(1, length, Easing.SinOut);
            }
            );*/

            /**
            * ATERNATIVE #2:  To do itin serial
            */
            Anim();
        }
        // used by Alternative #2
        private async void Anim()
        {
            await AvionImage.FadeTo(1, 100);
            await AvionImage.TranslateTo(0, 0, length, Easing.SinOut);
            await AvionImage.RotateTo(0, length, Easing.SinOut);
            await AvionImage.ScaleTo(1, length, Easing.SinOut);
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            
        }
    }
}