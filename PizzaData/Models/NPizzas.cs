using System;
using System.Collections.Generic;

namespace PizzaData.Models
{
    public partial class NPizzas
    {
        public NPizzas()
        {
            PizzaToppings = new HashSet<PizzaToppings>();
        }

        public int Id { get; set; }
        public int CrustTypeId { get; set; }
        public int CheeseTypeId { get; set; }
        public int SauceTypeId { get; set; }
        public string Name { get; set; }
        public string Size { get; set; }
        public bool isPremade { get; set; }

        public virtual CheeseTypes CheeseType { get; set; }
        public virtual CrustTypes CrustType { get; set; }
        public virtual SauceTypes SauceType { get; set; }
        public virtual ICollection<PizzaToppings> PizzaToppings { get; set; }

        public virtual ICollection<OrderPizzas> OrderPizzas { get; set; }
    }
}
