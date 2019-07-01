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
        
        enum e_tri
        {
            TRI_AUCUN,
            TRI_NOM,
            TRI_PRIX
        }
        e_tri tri = e_tri.TRI_AUCUN;

        const string KEY_TRI = "tri";

        private List<Pizza> pizzas;

        public MainPage()
        {
            InitializeComponent();

            if (Application.Current.Properties.ContainsKey(KEY_TRI))
            {
                tri = (e_tri)Application.Current.Properties[KEY_TRI];
                sortButton.Source = GetImageSourceFromTri(tri);
            }

            waitLayout.IsVisible = true;
            PizzalistView.IsVisible = false;
            PizzalistView.RefreshCommand = new Command((obj) =>
            {
                Console.WriteLine("Refresh command");
                PizzalistView.IsRefreshing = true;
                DownloadData((pizzas) =>
                {
                    PizzalistView.ItemsSource = GetPizzasFromTri(tri, pizzas);
                    PizzalistView.IsRefreshing = false;
                });
            });

            DownloadData((pizzas) =>
            {
                PizzalistView.ItemsSource = GetPizzasFromTri(tri, pizzas);
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
                          pizzas = JsonConvert.DeserializeObject<List<Pizza>>(pizzaJson);
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

        private void SortButton_Clicked(object sender, EventArgs e)
        {
            if (tri == e_tri.TRI_AUCUN)
            {
                tri = e_tri.TRI_NOM;
            } else if (tri == e_tri.TRI_NOM)
            {
                tri = e_tri.TRI_PRIX;
            }
            else if (tri == e_tri.TRI_PRIX)
            {
                tri = e_tri.TRI_AUCUN;
            }

            sortButton.Source = GetImageSourceFromTri(tri);
            PizzalistView.ItemsSource = GetPizzasFromTri(tri, pizzas);

            Application.Current.Properties[KEY_TRI] = (int)tri;
            Application.Current.SavePropertiesAsync();

        }
        private string GetImageSourceFromTri(e_tri t)
        {
            switch (t) {
                case e_tri.TRI_NOM:
                    return "sort_nom.png";
                case e_tri.TRI_PRIX:
                    return "sort_prix.png";
                default:
                    return "sort_none.png";
            }

        }

        private List<Pizza> GetPizzasFromTri(e_tri t, List<Pizza> l)
        {
            if (l == null) return null;

            switch (t)
            {
                case e_tri.TRI_NOM:
                    {
                        List<Pizza> ret = new List<Pizza>(l);
                        ret.Sort((p1, p2) => { return p1.Title.CompareTo(p2.Title); });
                        return ret;
                    }
                    
                case e_tri.TRI_PRIX:
                    {
                        List<Pizza> ret = new List<Pizza>(l);
                        ret.Sort((p1, p2) => { return p2.Prix.CompareTo(p1.Prix); });
                        return ret;
                    }

                default:
                    return l;
            }
        }
    }
}
