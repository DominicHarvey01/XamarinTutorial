using PizzApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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
            pizzas = new List<Pizza>();
            pizzas.Add(new Pizza { Nom = "Végétarienne", Prix = 5, Ingredients = new string[] { "tomate", "poivrons" } , Url= "https://upload.wikimedia.org/wikipedia/commons/a/a3/Eq_it-na_pizza-margherita_sep2005_sml.jpg"});
            pizzas.Add(new Pizza { Nom = "ALL DRESSED", Prix = 7, Ingredients = new string[] { "tomate", "poivrons", "pépéronnie", "Olive","camenbere","champigion", "camenbere", "champigion", "camenbere", "champigion" }, Url = "https://shawglobalnews.files.wordpress.com/2018/09/pizza-stock.gif?w=720&h=379&crop=1" });
            pizzas.Add(new Pizza { Nom = "HawaieN", Prix = 7, Ingredients = new string[] { "tomate", "poivrons", "anana" }, Url = "https://www.chicken.ca/assets/RecipePhotos/_resampled/FillWyIxNDQwIiwiNzAwIl0/PizzaMargherita.jpg" });

            //preparing binding in xaml
            PizzalistView.ItemsSource = pizzas;

        }

       


    }
}
