using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using PizzApp.Extension;
using Xamarin.Forms;

namespace PizzApp.Model
{
    class PizzaCell: INotifyPropertyChanged

    {
        public Pizza pizza { get ; set; }
        public bool isFavorite { get ; set; }

        public string ImageSourceFav { get { return isFavorite ? "star2.png" : "star1.png"; } }

        
        public PizzaCell()
        {
            FavClickCommand = new Command((obj) =>
            {
                Pizza param = obj as Pizza;

                Console.WriteLine("+++++++++++++++++++++++ FavClickCommand: "+ param.IngredientsStr);
                isFavorite = !isFavorite;
                OnPropertyChanged("ImageSourceFav");
                FavChangedAction.Invoke(this);

            });
        }
        public ICommand FavClickCommand { get; set; }
        public Action<PizzaCell> FavChangedAction { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
