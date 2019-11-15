using System;
using System.Collections.Generic;

namespace PizzaData.Models
{
    public partial class OrderSides
    {
        public int Id { get; set; }
        public int NOrderId { get; set; }
        public int SideId { get; set; }

        public virtual NOrders NOrder { get; set; }
        public virtual Sides Side { get; set; }
    }
}
