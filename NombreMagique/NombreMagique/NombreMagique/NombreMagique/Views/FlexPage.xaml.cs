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
    public partial class FlexPage : ContentPage
    {
        public FlexPage()
        {
            InitializeComponent();

        }

        private void MyBtn_Clicked(object sender, EventArgs e)
        {
            var label = new Label();
            label.Text = "test";
            myFlexLayout.Children.Add(label);
        }
    }
}