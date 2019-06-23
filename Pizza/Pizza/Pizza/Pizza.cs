using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaInternetConsole
{
    class Pizza
    {
        private string nom;
        private int prix;
        string[] ingredients;

        public Pizza(string nom, int prix, string[] ingredients)
        {
            this.nom = nom;
            this.prix = prix;
            this.ingredients = ingredients;
        }

        public void Afficher()
        {
            Console.WriteLine("Pizza:" + nom + " - " + prix + " $ ");
            Console.WriteLine(String.Join(", ", ingredients));
            Console.WriteLine("");

        }
    }
}
