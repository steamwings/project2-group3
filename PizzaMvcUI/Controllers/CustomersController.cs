using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PizzaData.Models;

namespace PizzaMvcUI.Controllers
{
    public class CustomersController : Controller
    {
        public async Task<IActionResult> Account()
        {
            if (TempData["User"] != null)
            {
                var user = await API.GetCustomer((int)TempData["User"]);
                return View(user);
            }
            else
            {
                return NotFound();
            }
        }

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
                var salt = await API.GetSalt(login.Email);
                if (salt == null)
                {
                    ModelState.AddModelError("Email", "Error: No user found with given email.");
                    return View(login);
                }
                var hashedPass = HashHelper.HashWithExistingSalt(login.Password, salt);
                var credentials = new LoginCredentials()
                {
                    Email = login.Email,
                    PasswordHash = hashedPass
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
        public async Task<IActionResult> Register(RegisterVM entry)
        {
            if (ModelState.IsValid)
            {
                var passHash = HashHelper.HashWithNewSalt(entry.Password, out string salt);
                var cust = new Customers()
                {
                    Email = entry.Email,
                    PasswordHash = passHash,
                    Salt = salt,
                    FirstName = entry.FirstName,
                    LastName = entry.LastName
                };

                // TODO API call to post new user, check for duplicate email error
            }
            return View(entry);
        }
    }
}