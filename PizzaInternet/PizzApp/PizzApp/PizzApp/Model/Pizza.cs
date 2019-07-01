using System;
using System.Collections.Generic;
using System.Text;
using PizzApp.Extension;

namespace PizzApp.Model
{
    class Pizza
    {
        public string Nom { get ; set; }
        public int Prix { get; set; }
        public string[] Ingredients { get; set; }

        public string PrixStr { get { return Prix + "$"; } }
        public string IngredientsStr { get {return String.Join(", ",Ingredients); }}

        public string Url { get; set; }

        //public string Title{ get { return StringExtension.PremiereLettreMajuscule(Nom); }}
        public string Title { get { return Nom.PremiereLettreMajuscule(); } }

        public Pizza()
        {

        }
    }
}
