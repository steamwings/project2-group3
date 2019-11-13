using System;
using System.Collections.Generic;

namespace PizzaData.Models
{
    public partial class CrustTypes
    {
        public CrustTypes()
        {
            Pizzas = new HashSet<Pizzas>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Pizzas> Pizzas { get; set; }
    }
}
