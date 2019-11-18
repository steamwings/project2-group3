﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PizzaData.Models;

namespace PizzaMvcUI.Controllers
{
    public class CustomersController : Controller
    {
        [HttpGet]
        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> LogIn([Bind("Email,Password")]LoginVM login)
        {
            if (ModelState.IsValid)
            {
                var credentials = new LoginCredentials()
                {
                    Email = login.Email,
                    PasswordHash = login.Password
                };
                int Id = await API.Login(credentials);
                TempData["User"] = Id;
                return RedirectToAction("Index", "Home");
            }
            return View(login);
        }

        public ActionResult LogOut()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterVM entry)
        {
            if (ModelState.IsValid)
            {
                // create new account here
            }
            return View(entry);
        }
    }
}