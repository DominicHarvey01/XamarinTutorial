using Newtonsoft.Json;
using PizzApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PizzApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private List<Pizza> pizzas;

        public MainPage()
        {
            InitializeComponent();

            waitLayout.IsVisible = true;
            PizzalistView.IsVisible = false;
            PizzalistView.RefreshCommand = new Command((obj) =>
            {
                Console.WriteLine("Refresh command");
                PizzalistView.IsRefreshing = true;
                DownloadData((pizzas) =>
                {
                    PizzalistView.ItemsSource = pizzas;
                    PizzalistView.IsRefreshing = false;
                });
            });

            DownloadData((pizzas) =>
            {
                PizzalistView.ItemsSource = pizzas;
                PizzalistView.IsVisible = true;
                waitLayout.IsVisible = false;

            });
        }

        //downloaddata use "delegate" Action<List<Pizza>> action
        void DownloadData(Action<List<Pizza>> action)
        {
            const string url = "https://drive.google.com/uc?export=download&id=1TaB00JR8lTfvxmg9m6k1N_Y4XH0zGwH3";
            using (var webClient = new WebClient())
            {
                webClient.DownloadStringCompleted += (object sender, DownloadStringCompletedEventArgs e) =>
                {
                   // Console.WriteLine("Donné télécharger: " + e.Result);
                   

                    try
                    {
                        string pizzaJson = e.Result;
                        List<Pizza> pizzas = JsonConvert.DeserializeObject<List<Pizza>>(pizzaJson);
                        Device.BeginInvokeOnMainThread(() =>
                            {
                        action.Invoke(pizzas);
                    });
                    }
                    catch (Exception ex)
                    {
                            // to prevent non display of error message occuring within the network thread.
                            Device.BeginInvokeOnMainThread(() =>
                        {
                            DisplayAlert("Erreur", "Une Erreur est survenue: " + ex.Message, "ok");
                            action.Invoke(null);
                        });
                    }

                };
                webClient.DownloadStringAsync(new Uri(url));



            }
        }
    }
}
