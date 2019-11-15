using System;
using System.Collections.Generic;

namespace PizzaData.Models
{
    public partial class PizzaToppings
    {
        public int Id { get; set; }
        public int NPizzaId { get; set; }
        public int ToppingId { get; set; }

        public virtual NPizzas NPizza { get; set; }
        public virtual Toppings Topping { get; set; }
    }
}

