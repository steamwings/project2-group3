﻿using System;
using System.Collections.Generic;

namespace PizzaData.Models
{
    public partial class Sides
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int PriceCategoryId { get; set; }

        public virtual ICollection<OrderSides> OrderSides { get; set; }
        public virtual PriceCategory PriceCategory { get; set; }
    }
}