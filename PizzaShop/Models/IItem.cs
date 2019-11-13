using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaShop.Models
{
    interface IItem
    {
        public decimal Price { get; set; }
    }
}
