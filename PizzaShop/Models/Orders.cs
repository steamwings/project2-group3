using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PizzaShop.Models
{
    public partial class Orders
    {
        public int Id { get; set; }
        public DateTime OrderTime { get; set; }
        public virtual ICollection<OrderPizzas> OrderPizzas { get; set; }
        public virtual ICollection<OrderSides> OrderSides { get; set; }
    }
}
