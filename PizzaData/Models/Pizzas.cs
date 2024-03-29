﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaData.Models
{
    public class Pizzas
    {
        public int CrustTypesId { get; set; }
        public int CheeseTypesId { get; set; }
        public int SauceTypesId { get; set; }
        public List<int> ToppingsId { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
        public string Size { get; set; }
    }
}
