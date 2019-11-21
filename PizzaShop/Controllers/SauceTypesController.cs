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
    public class SauceTypesController : ControllerBase
    {
        private readonly SauceTypesRepo _repo;

        public SauceTypesController(SauceTypesRepo repo)
        {
            _repo = repo;
        }

        // GET: api/SauceTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SauceTypes>>> GetSauceTypes()
        {
            return await _repo.Get().ToListAsync();
        }

        // GET: api/SauceTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SauceTypes>> GetSauceTypes(int id)
        {
            var sauceTypes = await _repo.Get(id);

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

            try
            {
                await _repo.Put(sauceTypes);
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
            
            await _repo.Post(sauceTypes);

            return CreatedAtAction("GetSauceTypes", new { id = sauceTypes.Id }, sauceTypes);
        }

        // DELETE: api/SauceTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SauceTypes>> DeleteSauceTypes(int id)
        {
            var sauceTypes = await _repo.Get(id);
            if (sauceTypes == null)
            {
                return NotFound();
            }

            
            await _repo.Delete(sauceTypes);

            return sauceTypes;
        }

        private bool SauceTypesExists(int id)
        {
            return _repo.Exists(id);
        }
    }
}
