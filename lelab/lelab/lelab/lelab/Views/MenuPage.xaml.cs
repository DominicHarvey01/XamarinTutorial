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
    public partial class MenuPage : ContentPage
    {
        public MenuPage()
        {
            InitializeComponent();
        }

        private void Counter_btn_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new CountPage());
        }
        private void Tabs_btn_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new TabsPage());
        }
        private void List_btn_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new ListPage());
        }

    }
}