using System;
using System.Collections.Generic;

namespace PizzaData.Models
{
    public partial class Recipes
    {
        public int Id { get; set; }
        public int PizzaId { get; set; }
        public int ToppingId { get; set; }

        public virtual Pizzas Pizza { get; set; }
        public virtual Toppings Topping { get; set; }
    }
}
