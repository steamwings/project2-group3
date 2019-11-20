using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PizzaMvcUI.Extensions;
using PizzaMvcUI.Models;

namespace PizzaMvcUI.Controllers
{
    public class ViewCartController : Controller
    {
        public async Task<IActionResult> Index()
        {
            CartVM cartVM = new CartVM {
                Menu = await API.GetMenu(),
                Cart = TempData.GetCart()
            };
            TempData.Keep("Cart");
            return View(cartVM);
        }
    }
}