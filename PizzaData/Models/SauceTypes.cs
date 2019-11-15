using System;
using System.Collections.Generic;

namespace PizzaData.Models
{
    public partial class SauceTypes
    {
        public SauceTypes()
        {
            NPizzas = new HashSet<NPizzas>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<NPizzas> NPizzas { get; set; }
    }
}
