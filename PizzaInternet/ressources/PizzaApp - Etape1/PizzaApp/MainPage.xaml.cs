using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaApp.Model;
using Xamarin.Forms;

namespace PizzaApp
{
    public partial class MainPage : ContentPage
    {
        List<Pizza> pizzas;

        public MainPage()
        {
            InitializeComponent();


            pizzas = new List<Pizza>();

            //imageUrl
            pizzas.Add(new Pizza { nom = "végétarienne", prix = 7, ingredients = new string[] { "tomate", "poivrons", "oignons" }, imageUrl= "https://upload.wikimedia.org/wikipedia/commons/thumb/a/a3/Eq_it-na_pizza-margherita_sep2005_sml.jpg/280px-Eq_it-na_pizza-margherita_sep2005_sml.jpg" });
            pizzas.Add(new Pizza { nom = "MONTAGNARDE", prix = 11, ingredients = new string[] { "reblochon", "pomme de terre", "oignons", "crème fraiche", "lardons", "olives", "tomates", "oeufs", "camembert" }, imageUrl= "https://assets.afcdn.com/recipe/20170105/24149_w1024h768c1cx2592cy1728.jpg" });
            pizzas.Add(new Pizza { nom = "Carnivore", prix = 14, ingredients = new string[] { "tomate", "viande hachée", "mozzarella" }, imageUrl = "https://recipes.timesofindia.com/photo/53110049.cms" });


            // completez le code

            listView.ItemsSource = pizzas;
        }
    }
}
