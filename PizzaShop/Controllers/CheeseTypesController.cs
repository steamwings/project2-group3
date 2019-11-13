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
    public class CheeseTypesController : ControllerBase
    {
        private readonly Project2DatabaseContext _context;

        public CheeseTypesController(Project2DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/CheeseTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CheeseTypes>>> GetCheeseTypes()
        {
            return await _context.CheeseTypes.ToListAsync();
        }

        // GET: api/CheeseTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CheeseTypes>> GetCheeseTypes(int id)
        {
            var cheeseTypes = await _context.CheeseTypes.FindAsync(id);

            if (cheeseTypes == null)
            {
                return NotFound();
            }

            return cheeseTypes;
        }

        // PUT: api/CheeseTypes/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCheeseTypes(int id, CheeseTypes cheeseTypes)
        {
            if (id != cheeseTypes.Id)
            {
                return BadRequest();
            }

            _context.Entry(cheeseTypes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CheeseTypesExists(id))
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

        // POST: api/CheeseTypes
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<CheeseTypes>> PostCheeseTypes(CheeseTypes cheeseTypes)
        {
            _context.CheeseTypes.Add(cheeseTypes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCheeseTypes", new { id = cheeseTypes.Id }, cheeseTypes);
        }

        // DELETE: api/CheeseTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CheeseTypes>> DeleteCheeseTypes(int id)
        {
            var cheeseTypes = await _context.CheeseTypes.FindAsync(id);
            if (cheeseTypes == null)
            {
                return NotFound();
            }

            _context.CheeseTypes.Remove(cheeseTypes);
            await _context.SaveChangesAsync();

            return cheeseTypes;
        }

        private bool CheeseTypesExists(int id)
        {
            return _context.CheeseTypes.Any(e => e.Id == id);
        }
    }
}
