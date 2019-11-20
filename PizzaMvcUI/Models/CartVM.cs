using PizzaData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaMvcUI.Models
{
    public class CartVM
    {
        public Cart Cart { get; set; }
        public Menu Menu { get; set; }
    }
}
