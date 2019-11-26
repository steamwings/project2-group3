using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaShop.Extensions
{
    public static class ListExtensions
    {
        public static bool IsNullOrEmpty<T>(this List<T> list)
        {
            return (list is null || list.Count == 0);
        } 
    }
}
