using System;
using System.Collections.Generic;

namespace PizzaShop.Models
{
    public partial class OrderPizzas
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int PizzaId { get; set; }
    }
}
