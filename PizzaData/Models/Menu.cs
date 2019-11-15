using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaData.Models
{
    public partial class Menu
    {
        public ICollection<Sides> Sides { get; set; }
    }
}
