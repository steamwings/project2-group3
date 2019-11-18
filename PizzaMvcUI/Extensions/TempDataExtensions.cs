﻿using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaMvcUI.Extensions
{
    public static class TempDataExtensions
    {
        public static void Set<T>(this ITempDataDictionary tempData, string key, T value) where T : class
        {
            tempData[key] = JsonConvert.SerializeObject(value);
        }
        public static T Get<T>(this ITempDataDictionary tempData, string key) where T : class
        {
            tempData.TryGetValue(key, out object o);
            return o == null ? null : JsonConvert.DeserializeObject<T>((string)o);
        }


        public static void SetCart(this ITempDataDictionary tempData, Cart cart)
        {
            tempData["Cart"] = JsonConvert.SerializeObject(cart);
        }

        public static Cart GetCart(this ITempDataDictionary tempData)
        {
            tempData.TryGetValue("Cart", out object o);
            return o == null ? null : JsonConvert.DeserializeObject<Cart>((string)o);
        }

    }
}
