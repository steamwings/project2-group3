using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaMvcUI.Extensions
{
    public static class TempDataExtensions
    {
        private static readonly string[] MyKeys = { "Cart", "User" };

        public static void KeepUserData(this ITempDataDictionary tempData)
        {
            foreach(var key in MyKeys) { tempData.Keep(key);  }
        }

        public static void Set<T>(this ITempDataDictionary tempData, string key, T value) where T : class
        {
            tempData[key] = JsonConvert.SerializeObject(value);
        }
        public static T Get<T>(this ITempDataDictionary tempData, string key) where T : class
        {
            object o = tempData.Peek(key);
            Console.WriteLine("[0]", o);
            return o == null ? null : JsonConvert.DeserializeObject<T>((string)o);
        }

        public static void SetCart(this ITempDataDictionary tempData, Cart cart)
        {
            tempData["Cart"] = JsonConvert.SerializeObject(cart);
            tempData.Keep();

        }

        public static Cart GetCart(this ITempDataDictionary tempData)
        {
           //tempData.TryGetValue("Cart", out object o);
            object o = tempData.Peek("Cart");
            return o == null ? null : JsonConvert.DeserializeObject<Cart>((string)o);
        }

    }
}
