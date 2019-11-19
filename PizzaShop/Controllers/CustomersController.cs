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
    public class CustomersController : ControllerBase
    {
        private readonly Project2DatabaseContext _context;

        public CustomersController(Project2DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customers>>> GetCustomers()
        {
            return await _context.Customers.ToListAsync();
        }

        // GET: api/Customers/Salt
        [Route("Salt")]
        [HttpPost]
        public async Task<ActionResult<string>> GetSalt(SaltRequest r)
        {
            try
            {
                return (await _context.Customers.SingleAsync(c => c.Email == r.Email)).Salt;
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

        // TODO: Remove this
        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customers>> GetCustomers(int id)
        {
            var customers = await _context.Customers.FindAsync(id);

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

            _context.Entry(customers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
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
            _context.Customers.Add(customers);
            try
            {
                await _context.SaveChangesAsync();
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
            Customers customer = await _context.Customers
                .Where(cust => cust.Email == loginCredentials.Email && cust.PasswordHash == loginCredentials.PasswordHash)
                .SingleOrDefaultAsync();
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
            var customers = await _context.Customers.FindAsync(id);
            if (customers == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(customers);
            await _context.SaveChangesAsync();

            return customers;
        }

        private bool CustomersExists(int id)
        {
            return _context.Customers.Any(e => e.Id == id);
        }
    }
}
