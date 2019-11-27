using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PizzaData.Models;
using PizzaMvcUI.Extensions;
using PizzaMvcUI.Models;

namespace PizzaMvcUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            if (TempData.Peek("Cart") == null)
            {
                TempData.SetCart(new Cart { Pizzas = new List<Pizzas>(), Sides = new List<int>(), PreMadePizzas = new List<int>() });
            }
            TempData.Keep("Cart");
            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new Models.ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
