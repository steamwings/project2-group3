using System;
using System.Collections.Generic;

namespace PizzaData.Models
{
    public partial class Pizzas
    {
        public Pizzas()
        {
            Recipes = new HashSet<PizzaToppings>();
        }

        public int Id { get; set; }
        public int CrustTypeId { get; set; }
        public int CheeseTypeId { get; set; }
        public int SauceTypeId { get; set; }
        public string Name { get; set; }

        public virtual CheeseTypes CheeseType { get; set; }
        public virtual CrustTypes CrustType { get; set; }
        public virtual SauceTypes SauceType { get; set; }
        public virtual ICollection<PizzaToppings> Recipes { get; set; }

        public virtual ICollection<OrderPizzas> OrderPizzas { get; set; }
    }
}
