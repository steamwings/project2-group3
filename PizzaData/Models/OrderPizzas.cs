﻿using System;
using System.Collections.Generic;

namespace PizzaData.Models
{
    public partial class OrderPizzas
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int PizzaId { get; set; }
        public virtual Pizzas Pizza { get; set; }
        public virtual Orders Order { get; set; }

    }
}