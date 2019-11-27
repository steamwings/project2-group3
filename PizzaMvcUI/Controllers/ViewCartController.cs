using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PizzaData.Models;
using PizzaMvcUI.Extensions;
using PizzaMvcUI.Models;

namespace PizzaMvcUI.Controllers
{
    public class ViewCartController : Controller
    {
        public async Task<IActionResult> Index()
        {
            CartVM cartVM = new CartVM {
                Items = await TempData.GetCart().GetItems()
            };

            return View(cartVM);
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmOrder()
        {
            Cart cart = TempData.GetCart();
            Orders order = new Orders {
                CustomerId = (int) TempData.Peek("User"),
                Pizzas = new List<Pizzas>(),
                PreMadePizzaIds = new List<int>(),
                SidesIds = new List<int>()
            };
            foreach (var p in cart.Pizzas)
            {
                order.Pizzas.Add(p);
            }
            foreach (var p in cart.PreMadePizzas)
            {
                order.PreMadePizzaIds.Add(p);
            }
            foreach (var s in cart.Sides)
            {
                order.SidesIds.Add(s);
            }
            var statusCode = await API.PostOrder(order);

            if (statusCode == HttpStatusCode.Created)
            {
                TempData.SetCart(new Cart { Pizzas = new List<Pizzas>(), Sides = new List<int>(), PreMadePizzas = new List<int>() });
                return RedirectToAction("OrderSuccess");
            }
            return RedirectToAction("Index");
        }

        public IActionResult OrderSuccess()
        {
            return View();
        }
    }
}