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
    public class SauceTypesController : ControllerBase
    {
        private readonly Project2DatabaseContext _context;

        public SauceTypesController(Project2DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/SauceTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SauceTypes>>> GetSauceTypes()
        {
            return await _context.SauceTypes.ToListAsync();
        }

        // GET: api/SauceTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SauceTypes>> GetSauceTypes(int id)
        {
            var sauceTypes = await _context.SauceTypes.FindAsync(id);

            if (sauceTypes == null)
            {
                return NotFound();
            }

            return sauceTypes;
        }

        // PUT: api/SauceTypes/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSauceTypes(int id, SauceTypes sauceTypes)
        {
            if (id != sauceTypes.Id)
            {
                return BadRequest();
            }

            _context.Entry(sauceTypes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SauceTypesExists(id))
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

        // POST: api/SauceTypes
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<SauceTypes>> PostSauceTypes(SauceTypes sauceTypes)
        {
            _context.SauceTypes.Add(sauceTypes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSauceTypes", new { id = sauceTypes.Id }, sauceTypes);
        }

        // DELETE: api/SauceTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SauceTypes>> DeleteSauceTypes(int id)
        {
            var sauceTypes = await _context.SauceTypes.FindAsync(id);
            if (sauceTypes == null)
            {
                return NotFound();
            }

            _context.SauceTypes.Remove(sauceTypes);
            await _context.SaveChangesAsync();

            return sauceTypes;
        }

        private bool SauceTypesExists(int id)
        {
            return _context.SauceTypes.Any(e => e.Id == id);
        }
    }
}
