using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaData.Models;

namespace PizzaShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly Project2DatabaseContext _context;

        public OrdersController(Project2DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NOrders>>> GetOrders()
        {
            return await _context.NOrders.ToListAsync();
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NOrders>> GetOrders(int id)
        {
            var orders = await _context.NOrders.FindAsync(id);

            if (orders == null)
            {
                return NotFound();
            }

            return orders;
        }

        // PUT: api/Orders/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrders(int id, NOrders orders)
        {
            if (id != orders.Id)
            {
                return BadRequest();
            }

            _context.Entry(orders).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrdersExists(id))
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

        // POST: api/Orders
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<NOrders>> PostOrders(Orders order)
        {
            NOrders nOrder = new NOrders
            {
                CustomerId = order.CustomerId,
                OrderTime = order.OrderTime,
            };
            _context.NOrders.Add(nOrder);
            await _context.SaveChangesAsync();
            foreach (var pizza in order.Pizzas)
            {
                NPizzas nPizza = new NPizzas
                {
                    CheeseTypeId = pizza.CheeseTypesId,
                    CrustTypeId = pizza.CrustTypesId,
                    SauceTypeId = pizza.SauceTypesId,
                    Size = pizza.Size,
                    Name = pizza.Name
                };
                _context.NPizzas.Add(nPizza);
                await _context.SaveChangesAsync();
                _context.OrderPizzas.Add(new OrderPizzas
                {
                    NOrderId = nOrder.Id,
                    NPizzaId = nPizza.Id
                });
                await _context.SaveChangesAsync();
                foreach (var topping in pizza.ToppingsId)
                {
                    _context.PizzaToppings.Add(new PizzaToppings { 
                         NPizzaId = nPizza.Id,
                         ToppingId = topping
                    });
                    await _context.SaveChangesAsync();
                }
            }
            foreach (var sideId in order.SidesIds)
            {
                OrderSides os = new OrderSides
                {
                    NOrderId = nOrder.Id,
                    SideId = sideId
                };
                _context.OrderSides.Add(os);
                await _context.SaveChangesAsync();
            }
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrders", new { id = nOrder.Id }, nOrder.Id);
        }

        public int GetEstimatePickupTime()
        {
            Random random = new Random();
            return (int)Math.Round(random.Next(10, 75) / 5.0) * 5;
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<NOrders>> DeleteOrders(int id)
        {
            var orders = await _context.NOrders.FindAsync(id);
            if (orders == null)
            {
                return NotFound();
            }

            _context.NOrders.Remove(orders);
            await _context.SaveChangesAsync();

            return orders;
        }

        private bool OrdersExists(int id)
        {
            return _context.NOrders.Any(e => e.Id == id);
        }
    }
}
