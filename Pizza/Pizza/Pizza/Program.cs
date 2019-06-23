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




namespace PizzaInternetConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            const string URL = "https://codeavecjonathan.com/res/pizzas1.json";

            //string pizzasJson = "[{\"nom\":\"4 fromage\",\"prix\":\"10\",  \"ingredients\":[\"fromage1\",\"fromage2\",\"fromage3\",\"fromage4\"]},{\"nom\":\"Vegé\",\"prix\":\"7\",\"ingredients\":[\"Tomate\", \"Poivron\"]}]";

            /*
             * "using" will distroy the WebClient after the closed }
             */
            string pizzasJson = "";


            using (var WebClient = new WebClient())
            {
                try
                {
                    pizzasJson = WebClient.DownloadString(URL);
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
            List<Pizza> pizzas = JsonConvert.DeserializeObject<List<Pizza>>(pizzasJson);



            foreach (Pizza p in pizzas)
            {
                p.Afficher();
            }

        }
    }
}
