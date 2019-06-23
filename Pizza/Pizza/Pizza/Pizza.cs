using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza
{
    class Pizza
    {
        private string nom;
        private int prix;
        string[] ingredients;
        bool vegetarienne;

        public Pizza(string nom, int prix, string[] ingredients, bool vegetarienne)
        {
            this.nom = nom;
            this.prix = prix;
            this.ingredients = ingredients;
            this.vegetarienne = vegetarienne;
        }

        public void Afficher()
        {
            string vege = vegetarienne ? " (V)" : "";            

            Console.WriteLine("Pizza:" + nom + vege + " - " + prix + " $ ");
            Console.WriteLine(String.Join(", ", ingredients));
            Console.WriteLine("");

        }

        // a function
        public int GetPrix()
        {
            return prix;
        }
        // a property
        public int Prix
        {
            get { return prix; }
        }

        public string GetNom()
        {
            return nom;
        }
        public string Nom
        {
            get { return nom; }
        }
    }
}
