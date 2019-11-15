using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaData.Models
{
    public partial class Menu
    {
        public ICollection<CheeseTypes> Cheeses { get; set; }
        public ICollection<CrustTypes> Crusts { get; set; }
        public ICollection<SauceTypes> Sauces { get; set; }
        public ICollection<Sides> Sides { get; set; }
        public ICollection<Toppings> Toppings { get; set; }
    }
}
