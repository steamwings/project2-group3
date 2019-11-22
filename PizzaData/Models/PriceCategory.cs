using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaData.Models
{
    public class PriceCategory
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }

        public virtual ICollection<CrustTypes> CrustTypes { get; set; }
        public virtual ICollection<SauceTypes> SauceTypes { get; set; }
        public virtual ICollection<CheeseTypes> CheeseTypes { get; set; }
        public virtual ICollection<Toppings> Toppings { get; set; }
        public virtual ICollection<Sides> Sides { get; set; }
    }
}
