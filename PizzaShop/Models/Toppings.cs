using System;
using System.Collections.Generic;

namespace PizzaShop.Models
{
    public partial class Toppings
    {
        public Toppings()
        {
            Recipes = new HashSet<Recipes>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Recipes> Recipes { get; set; }
    }
}
