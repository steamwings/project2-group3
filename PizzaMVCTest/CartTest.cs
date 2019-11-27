using NUnit.Framework;
using PizzaData.Models;
using PizzaMvcUI;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PizzaMVCTest
{
    public class CartTest
    {
        [Test]
        public async Task Test1()
        {
            var cart = new Cart { Pizzas = new List<Pizzas>(), Sides = new List<int>() };
            var items = await cart.GetItems();
            Assert.AreEqual("No Items to Display", items.Find(i => i.Name == "No Items to Display").Name);
        }
    }
}
