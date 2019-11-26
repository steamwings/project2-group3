using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaData.Models;
using PizzaShop.Repositories;

namespace PizzaShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomersRepo _repo;
        private readonly INOrdersRepo _nOrdersRepo;

        public CustomersController(ICustomersRepo repo, INOrdersRepo nOrdersRepo)
        {
            _repo = repo;
            _nOrdersRepo = nOrdersRepo;
        }

        // GET: api/Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customers>>> GetCustomers()
        {
            return await _repo.Get().ToListAsync();
        }

        // GET: api/Customers/Salt
        [Route("Salt")]
        [HttpPost]
        public async Task<ActionResult<string>> GetSalt(SaltRequest r)
        {
            try
            {
                return (await _repo.Get().SingleAsync(c => c.Email == r.Email)).Salt;
            }
            catch (ArgumentNullException) // TODO Grab exception and log it
            {
                return Problem("Server error.", statusCode:500);
            }
            catch(InvalidOperationException)
            {
                return NotFound();
            }
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customers>> GetCustomers(int id)
        {
            var customers = await _repo.Get(id);

            if (customers == null)
            {
                return NotFound();
            }

            return customers;
        }

        // PUT: api/Customers/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomers(int id, Customers customers)
        {
            if (id != customers.Id)
            {
                return BadRequest();
            }

            try
            {
                await _repo.Edit(customers);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomersExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Customers
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Customers>> PostCustomers(Customers customers)
        {
            // check for duplicate Email
            if (_repo.Exists(customers.Email))
            {
                return Conflict();
            }

            try
            {
                await _repo.Add(customers);
                return CreatedAtAction("GetCustomers", new { id = customers.Id }, customers.Id);
            }
            catch (DbUpdateException)
            {
                return new StatusCodeResult(422);
            }
        }

        //POST: api/Customers/Login
        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult> Login(LoginCredentials loginCredentials)
        {
            Customers customer = await _repo.Login(loginCredentials);
            if (customer != null)
            {
                return Ok(customer.Id);
            }
            else
            {
                return NotFound();
            }
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Customers>> DeleteCustomers(int id)
        {
            var customers = await _repo.Get(id);
            if (customers == null)
            {
                return NotFound();
            }

            await _repo.Remove(customers);

            return customers;
        }

        [HttpGet("{id}/OrderHistory")]
        public ActionResult<List<Orders>> GetOrders(int id)
        {
            var nOrders = _nOrdersRepo.GetByCustomerId(id);

            if (nOrders == null)
            {
                return NotFound();
            }

            List<Orders> orders = new List<Orders>();
            foreach (var nOrder in nOrders)
            {
                Orders order = new Orders
                {
                    CustomerId = nOrder.CustomerId,
                    OrderTime = nOrder.OrderTime,
                    Pizzas = new List<Pizzas>(),
                    PreMadePizzaIds = new List<int>(),
                    SidesIds = new List<int>()
                };
                foreach (var oPizzas in nOrder.OrderPizzas)
                {
                    Pizzas pizza = new Pizzas
                    {
                        CheeseTypesId = oPizzas.NPizza.CheeseTypeId,
                        CrustTypesId = oPizzas.NPizza.CrustTypeId,
                        SauceTypesId = oPizzas.NPizza.SauceTypeId,
                        ToppingsId = new List<int>()
                    };
                    foreach (var topping in oPizzas.NPizza.PizzaToppings)
                    {
                        pizza.ToppingsId.Add(topping.ToppingId);
                    }
                    order.Pizzas.Add(pizza);
                }
                foreach (var oSides in nOrder.OrderSides)
                {
                    order.SidesIds.Add(oSides.SideId);
                }
                foreach (var oPMPizzas in nOrder.OrderPreMadePizzas)
                {
                    order.PreMadePizzaIds.Add(oPMPizzas.PreMadePizzaId);
                }
                orders.Add(order);
            }
            return orders;
        }

        private bool CustomersExists(int id)
        {
            return _repo.Exists(id);
        }
    }
}
