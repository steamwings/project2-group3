using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PizzaData.Models
{
    public partial class NOrders
    {
        public int Id { get; set; }
        public DateTime OrderTime { get; set; }
        public int CustomerId { get; set; }
        public virtual Customers Customer { get; set; }
        public virtual ICollection<OrderPizzas> OrderPizzas { get; set; }
        public virtual ICollection<OrderSides> OrderSides { get; set; }
        public virtual ICollection<OrderPreMadePizzas> OrderPreMadePizzas { get; set; }
    }
}
