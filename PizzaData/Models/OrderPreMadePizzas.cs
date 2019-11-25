using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaData.Models
{
    public class OrderPreMadePizzas
    {
        public int Id { get; set; }
        public int NOrderId { get; set; }
        public int PreMadePizzaId { get; set; }

        public virtual NOrders NOrder { get; set; }
        public virtual PreMadePizzas PreMadePizza { get; set; }
    }
}
