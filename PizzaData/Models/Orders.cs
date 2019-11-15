using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaData.Models
{
    public class Order
    {
        public List<Pizzas> Pizzas { get; set; }
        public List<Sides> Sides { get; set; }
        public DateTime OrderTime { get; set; }
        public int CustomerId { get; set; }
    }
}
