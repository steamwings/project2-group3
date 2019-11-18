using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaData.Models;

namespace PizzaMvcUI.Controllers
{
    public class PizzasController : Controller
    {
        public async Task<ActionResult> SelectCrust(int id)
        {
            CrustTypes c = await API.GetCrust(id);
            return View("Message", $"You selected {c.Name}");
        }

        // GET: Pizzas
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Build()
        {
            return View();
        }

        // GET: Pizzas/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Pizzas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pizzas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Pizzas/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Pizzas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Pizzas/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Pizzas/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}