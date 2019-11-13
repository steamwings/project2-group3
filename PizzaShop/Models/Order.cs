using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaShop.Models
{
    public class Order
    {
        int customerid;
        DateTime date;
        List<I_Item> items;
    }
}
