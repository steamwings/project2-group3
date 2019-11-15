using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaData.Models
{
    class Pizzas
    {
        public int CrustTypesId { get; set; }
        public int CheeseTypesId { get; set; }
        public int SauceTypesId { get; set; }
        public List<int> ToppingsId { get; set; }
    }
}
