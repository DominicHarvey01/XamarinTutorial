using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza
{
    class ContenuJson
    {
        public List<Pizza> pizzas;
        public Reglages reglages;

        public ContenuJson(List<Pizza> pizzas, Reglages reglages)
        {
            this.pizzas = pizzas;
            this.reglages = reglages;
        }
    }
}
