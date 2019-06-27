using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace lelab.Views
{
    public class Article
    {
        public string Nom { get; set; }
        public string Prix { get; set; }
        public string Description { get; set; }
    }
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListPage : ContentPage
    {
        List<Article> articles;

        public ListPage()
        {
            InitializeComponent();

            // Adding articles
            articles = new List<Article>();
            articles.Add(new Article { Nom = "Lait", Prix = "4$", Description="1.5%" });
            articles.Add(new Article { Nom = "Chocolat", Prix = "2$", Description = "Le meilleur Chocolat" });
            articles.Add(new Article { Nom = "Beurre", Prix = "5$", Description = "sallé" });
            articles.Add(new Article { Nom = "Pain", Prix = "3$", Description = "50 tranches" });

            maListView.ItemsSource = articles;

            // Adding list item on click event.
            maListView.ItemSelected += (sender, e) =>
            {
                if (maListView.SelectedItem != null)
                {
                    // obtaining selected article.
                    Article item = maListView.SelectedItem as Article;

                    DisplayAlert(item.Nom, item.Description, "OK");
                }
                maListView.SelectedItem = null;
            };

        }
    }
}