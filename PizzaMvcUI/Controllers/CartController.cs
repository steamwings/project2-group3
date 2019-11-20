using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc;
using PizzaMvcUI.Extensions;
using PizzaData.Models;

namespace PizzaMvcUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartAPIController : Controller
    {
        // GET: api/Cart
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Cart/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpGet]
        [Route("crust/{id}")]
        public void PostCrust(int id)
        {
            Cart cart = TempData.GetCart();
            cart.BuildPizza();
            cart.AddCrust(id);
            TempData.Keep("Cart");
        }

        [HttpGet]
        [Route("cheese/{id}")]
        public void PostCheese(int id)
        {
            Cart cart = TempData.GetCart();
            cart.AddCheese(id);
            TempData.Keep("Cart");
        }

        [HttpGet]
        [Route("sauce/{id}")]
        public void PostSauce(int id)
        {
            Cart cart = TempData.GetCart();
            cart.AddSauce(id);
            TempData.Keep("Cart");
        }

        [HttpGet]
        [Route("topping/{id}")]
        public void PostTopping(int id)
        {
            Cart cart = TempData.GetCart();
            cart.AddTopping(id);
            TempData.Keep("Cart");
        }

        [HttpGet]
        [Route("AddPizza")]
        public void PostPizza()
        {
            Cart cart = TempData.GetCart();
            cart.AddPizza();
            TempData.Keep("Cart");
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
