using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaShop.Models;

namespace PizzaShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToppingsController : ControllerBase
    {
        private readonly Project2DatabaseContext _context;

        public ToppingsController(Project2DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Toppings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Toppings>>> GetToppings()
        {
            return await _context.Toppings.ToListAsync();
        }

        // GET: api/Toppings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Toppings>> GetToppings(int id)
        {
            var toppings = await _context.Toppings.FindAsync(id);

            if (toppings == null)
            {
                return NotFound();
            }

            return toppings;
        }

        // PUT: api/Toppings/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutToppings(int id, Toppings toppings)
        {
            if (id != toppings.Id)
            {
                return BadRequest();
            }

            _context.Entry(toppings).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ToppingsExists(id))
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

        // POST: api/Toppings
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Toppings>> PostToppings(Toppings toppings)
        {
            _context.Toppings.Add(toppings);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetToppings", new { id = toppings.Id }, toppings);
        }

        // DELETE: api/Toppings/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Toppings>> DeleteToppings(int id)
        {
            var toppings = await _context.Toppings.FindAsync(id);
            if (toppings == null)
            {
                return NotFound();
            }

            _context.Toppings.Remove(toppings);
            await _context.SaveChangesAsync();

            return toppings;
        }

        private bool ToppingsExists(int id)
        {
            return _context.Toppings.Any(e => e.Id == id);
        }
    }
}
