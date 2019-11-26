using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc;
using PizzaMvcUI.Extensions;
using PizzaData.Models;
using System.Threading;

namespace PizzaMvcUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : Controller
    {
        // GET: api/Cart
        [HttpGet]
        public Cart Get()
        {
            return TempData.GetCart();
        }

        [HttpGet]
        [Route("crust/{id}")]
        public void PostCrust(int id)
        {
            Cart cart = TempData.GetCart();
            cart.BuildPizza();
            cart.AddCrust(id);
            TempData.SetCart(cart);
        }

        [HttpGet]
        [Route("cheese/{id}")]
        public void PostCheese(int id)
        {
            Cart cart = TempData.GetCart();
            cart.AddCheese(id);
            TempData.SetCart(cart);
        }

        [HttpGet]
        [Route("sauce/{id}")]
        public void PostSauce(int id)
        {
            Cart cart = TempData.GetCart();
            cart.AddSauce(id);
            TempData.SetCart(cart);
        }

        [HttpGet]
        [Route("topping/{id}")]
        public void PostTopping(int id)
        {
            Cart cart = TempData.GetCart();
            cart.AddTopping(id);
            TempData.SetCart(cart);
        }

        [HttpGet]
        [Route("AddPizza")]
        public void PostPizza()
        {
            Cart cart = TempData.GetCart();
            cart.AddPizza();
            TempData.SetCart(cart);
        }

        [HttpGet]
        [Route("AddSide/{id}")]
        public void PostSide(int id)
        {
            Cart cart = TempData.GetCart();
            cart.AddSide(id);
            TempData.SetCart(cart);
        }

        // POST: api/Cart
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Cart/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
