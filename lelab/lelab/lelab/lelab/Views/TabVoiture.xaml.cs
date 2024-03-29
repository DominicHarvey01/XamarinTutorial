﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace lelab.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TabVoiture : ContentPage
    {
        public TabVoiture()
        {
            InitializeComponent();
            voitureImage.Opacity = 0;
            voitureImage.TranslationX = 0;

        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            voitureImage.FadeTo(1,1000);
            voitureImage.TranslateTo(50, 0, 1000, Easing.SinInOut);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            voitureImage.Opacity = 0;
            voitureImage.TranslationX = 0;
        }
    }
}