using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaData.Models
{
    public partial class Menu
    {
        public ICollection<CheeseTypesVM> Cheeses { get; set; }
        public ICollection<CrustTypesVM> Crusts { get; set; }
        public ICollection<SauceTypesVM> Sauces { get; set; }
        public ICollection<SidesVM> Sides { get; set; }
        public ICollection<ToppingsVM> Toppings { get; set; }
    }
}
