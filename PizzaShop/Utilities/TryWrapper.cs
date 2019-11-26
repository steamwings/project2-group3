using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaShop.Utilities
{
    public static class TryWrapper
    {
        public static T TryCatch<T>(Func<T> func){
            try
            {
                return func();
            }catch(Exception e)
            {
                Log.Error(e, "Error in function func.ToString()");
                return default(T);
            }
        }
    }
}
