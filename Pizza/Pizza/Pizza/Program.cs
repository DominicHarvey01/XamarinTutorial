using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

/**
 * Add Json.net package Nuget
 * See https://jsoneditoronline.org/ to create /manipulate JSON package.
 */
using Newtonsoft.Json;




namespace Pizza
{
    class Program
    {
        static void Main(string[] args)
        {
            //const string URL = "https://codeavecjonathan.com/res/pizzas3.json";
            //string pizzasJson = "[{\"nom\":\"4 fromage\",\"prix\":\"10\",  \"ingredients\":[\"fromage1\",\"fromage2\",\"fromage3\",\"fromage4\"]},{\"nom\":\"Vegé\",\"prix\":\"7\",\"ingredients\":[\"Tomate\", \"Poivron\"]}]";

            /*
             * 1. Mettre un fichier sur google drive.
             * 2. parager avec tout le monde (public)
             * 3. faire get link.
             * 4. Aller sur https://sites.google.com/site/gdocs2direct/
             * 5. obtenir un lien de téléchargement pour le lien généré à l'étape #2.
             * 6. utiliser ce nouveau lien pour le url du web client
             */
              const string URL = "https://drive.google.com/uc?export=download&id=1Dqv7ANJ8Omwq-Qn6CFgPk_waLlbSwQRV";

            
            /*
             * "using" will distroy the WebClient after the closed }
             */
            string pizzasJson = "";

            Console.Write("Téléchargement...");
            using (var WebClient = new WebClient())
            {
                try
                {
                    pizzasJson = WebClient.DownloadString(URL);
                    Console.WriteLine("OK");
                }
                   catch(WebException e)
                {
                    string message = e.Message;

                    if (e.Status == WebExceptionStatus.ProtocolError)
                    {
                        message = "Vérifier votre url.";
                    }

                    if (e.Status == WebExceptionStatus.NameResolutionFailure)
                    {
                        message = "Vérifier votre accès réseaux.";
                    }

                    Console.WriteLine("ERROR: "+ message);
                    return;
                }
            }


            // Loading json data into variable.
            /**
             * DESERIALIZATION
             */
            ContenuJson contenuJson = JsonConvert.DeserializeObject<ContenuJson>(pizzasJson);
            List<Pizza> pizzas = contenuJson.pizzas;


           

            if (contenuJson.reglages.tri.Equals("prix"))
            {
                // sorting by price using lamda expression.
                pizzas.Sort((p1, p2) => { return p2.Prix.CompareTo(p1.Prix); });
            }
            else if (contenuJson.reglages.tri.Equals("nom"))
            {
                pizzas.Sort((p1, p2) => { return p1.Nom.CompareTo(p2.Nom); });
            }


            foreach (Pizza p in pizzas)
            {
                p.Afficher();
            }

        }
    }
}
