using System;
using System.Collections.Generic;

namespace PizzaData.Models
{
    public partial class PreMadePizzas
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int PriceCategoryId { get; set; }

        public virtual ICollection<OrderPreMadePizzas> OrderPreMadePizzas { get; set; }
        public virtual PriceCategory PriceCategory { get; set; }
    }
}
