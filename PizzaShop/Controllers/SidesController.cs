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
    public class SidesController : ControllerBase
    {
        private readonly Project2DatabaseContext _context;

        public SidesController(Project2DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Sides
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sides>>> GetSides()
        {
            return await _context.Sides.ToListAsync();
        }

        // GET: api/Sides/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sides>> GetSides(int id)
        {
            var sides = await _context.Sides.FindAsync(id);

            if (sides == null)
            {
                return NotFound();
            }

            return sides;
        }

        // PUT: api/Sides/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSides(int id, Sides sides)
        {
            if (id != sides.Id)
            {
                return BadRequest();
            }

            _context.Entry(sides).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SidesExists(id))
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

        // POST: api/Sides
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Sides>> PostSides(Sides sides)
        {
            _context.Sides.Add(sides);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSides", new { id = sides.Id }, sides);
        }

        // DELETE: api/Sides/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Sides>> DeleteSides(int id)
        {
            var sides = await _context.Sides.FindAsync(id);
            if (sides == null)
            {
                return NotFound();
            }

            _context.Sides.Remove(sides);
            await _context.SaveChangesAsync();

            return sides;
        }

        private bool SidesExists(int id)
        {
            return _context.Sides.Any(e => e.Id == id);
        }
    }
}
