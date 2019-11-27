using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PizzaData.Models;
using PizzaMvcUI.Utilities;

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
            return View("Login");
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
                var statusCode = await API.CreateCustomer(cust);
                if (statusCode == HttpStatusCode.Conflict)
                {
                    ModelState.AddModelError("Email", "Error: Email already in use.");
                    return View(entry);
                }
                else if (statusCode == HttpStatusCode.UnprocessableEntity)
                {
                    ModelState.AddModelError("Password", "Error: The registration could not be processed.");
                    return View(entry);
                }
                else if (statusCode == HttpStatusCode.Created)
                {
                    return RedirectToAction("RegisterSuccess");
                }
            }
            return View(entry);
        }

        public IActionResult RegisterSuccess()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> OrderHistory()
        {
            int customerId = (int)TempData.Peek("User");
            List<Orders> orders = await API.GetOrderHistory(customerId);
            Menu menu = await API.GetMenu();
            return View(new OrderHistoryVM { orders = orders, menu = menu});
        }

    }
}