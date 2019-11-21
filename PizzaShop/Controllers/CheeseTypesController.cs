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
    public class CheeseTypesController : ControllerBase
    {
        private readonly CheeseTypesRepo _repo;

        public CheeseTypesController(CheeseTypesRepo repo)
        {
            _repo = repo;
        }

        // GET: api/CheeseTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CheeseTypes>>> GetCheeseTypes()
        {
            return await _repo.Get().ToListAsync();
        }

        // GET: api/CheeseTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CheeseTypes>> GetCheeseTypes(int id)
        {
            var cheeseTypes = await _repo.Get(id);

            if (cheeseTypes is null)
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

            try
            {
                await _repo.Edit(cheeseTypes);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CheeseTypesExists(id))
                {
                    return NotFound();
                }
                else
                {
                 //TODO Exception Logging
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
            await _repo.Add(cheeseTypes);

            return CreatedAtAction("GetCheeseTypes", new { id = cheeseTypes.Id }, cheeseTypes);
        }

        // DELETE: api/CheeseTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CheeseTypes>> DeleteCheeseTypes(int id)
        {
            var cheeseTypes = await _repo.Get(id);
            if (cheeseTypes == null)
            {
                return NotFound();
            }

            await _repo.Remove(cheeseTypes);

            return cheeseTypes;
        }

        private bool CheeseTypesExists(int id)
        {
            return _repo.Exists(id);
        }
    }
}
