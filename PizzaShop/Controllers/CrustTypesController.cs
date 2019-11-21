using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaData.Models;
using PizzaShop.Repositories;

namespace PizzaShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrustTypesController : ControllerBase
    {
        private readonly CrustTypesRepo _repo;

        public CrustTypesController(CrustTypesRepo repo)
        {
            _repo = repo;
        }

        // GET: api/CrustTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CrustTypes>>> GetCrustTypes()
        {
            return await _repo.Get().ToListAsync();
        }

        // GET: api/CrustTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CrustTypes>> GetCrustTypes(int id)
        {
            var crustTypes = await _repo.Get(id);

            if (crustTypes == null)
            {
                return NotFound();
            }

            return crustTypes;
        }

        // PUT: api/CrustTypes/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCrustTypes(int id, CrustTypes crustTypes)
        {
            if (id != crustTypes.Id)
            {
                return BadRequest();
            }

            try
            {
                await _repo.Edit(crustTypes);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CrustTypesExists(id))
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

        // POST: api/CrustTypes
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<CrustTypes>> PostCrustTypes(CrustTypes crustTypes)
        {
            
            await _repo.Add(crustTypes);

            return CreatedAtAction("GetCrustTypes", new { id = crustTypes.Id }, crustTypes);
        }

        // DELETE: api/CrustTypes/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<CrustTypes>> DeleteCrustTypes(int id)
        {
            var crustTypes = await _repo.Get(id);
            if (crustTypes == null)
            {
                return NotFound();
            }

            await _repo.Remove(crustTypes);

            return crustTypes;
        }

        private bool CrustTypesExists(int id)
        {
            return _repo.Exists(id);
        }
    }
}
