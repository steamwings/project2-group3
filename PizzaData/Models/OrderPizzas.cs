using System;
using System.Collections.Generic;

namespace PizzaData.Models
{
    public partial class OrderPizzas
    {
        public int Id { get; set; }
        public int NOrderId { get; set; }
        public int NPizzaId { get; set; }
        public virtual NPizzas NPizza { get; set; }
        public virtual NOrders NOrder { get; set; }

    }
}
