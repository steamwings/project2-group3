using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PizzaMvcUI.Controllers
{
    public class SidesController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View(await API.GetSides());
        }
    }
}