﻿using System;
using System.Collections.Generic;

namespace PizzaShop.Models
{
    public partial class OrderSides
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int SideId { get; set; }
    }
}
