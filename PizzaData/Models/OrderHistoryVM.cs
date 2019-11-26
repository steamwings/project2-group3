using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaData.Models
{
    public class OrderHistoryVM
    {
        public List<Orders> orders { get; set; }
        public Menu menu { get; set; }
    }
}
