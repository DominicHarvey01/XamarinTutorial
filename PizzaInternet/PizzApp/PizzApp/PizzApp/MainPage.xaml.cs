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
            pizzas.Add(new Pizza { Nom = "Végétarienne", Prix = 5, Ingredients = new string[] { "tomate", "poivrons" } });
            pizzas.Add(new Pizza { Nom = "All dressed", Prix = 7, Ingredients = new string[] { "tomate", "poivrons", "pépéronnie" } });
            pizzas.Add(new Pizza { Nom = "Hawaien", Prix = 7, Ingredients = new string[] { "tomate", "poivrons", "anana" } });
        }
    }
}
