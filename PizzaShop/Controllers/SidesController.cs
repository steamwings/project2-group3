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
    public class SidesController : ControllerBase
    {
        private readonly IBasicRepo<Sides> _repo;

        public SidesController(IBasicRepo<Sides> repo)
        {
            _repo = repo;
        }

        // GET: api/Sides
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SidesVM>>> GetSides()
        {
            return ConvertToVM(await _repo.Get().ToListAsync());
        }

        // GET: api/Sides/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SidesVM>> GetSides(int id)
        {
            var sides = await _repo.Get(id);

            if (sides == null)
            {
                return NotFound();
            }

            return ConvertToVM(sides);
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

            try
            {
                await _repo.Edit(sides);
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
            
            await _repo.Add(sides);

            return CreatedAtAction("GetSides", new { id = sides.Id }, sides);
        }

        // DELETE: api/Sides/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SidesVM>> DeleteSides(int id)
        {
            var sides = await _repo.Get(id);
            if (sides == null)
            {
                return NotFound();
            }

            await _repo.Remove(sides);

            return ConvertToVM(sides);
        }

        private bool SidesExists(int id)
        {
            return _repo.Exists(id);
        }



        public SidesVM ConvertToVM(Sides sides)
        {
            SidesVM returnSide = new SidesVM
            {
                Id = sides.Id,
                Name = sides.Name,
                Description = sides.Description,
                Price = sides.PriceCategory.Price
            };

            return returnSide;
        }

        public List<SidesVM> ConvertToVM(List<Sides> sauceTypes)
        {
            List<SidesVM> returnSides = new List<SidesVM>();
            foreach (var item in sauceTypes)
            {
                returnSides.Add(ConvertToVM(item));
            }
            return returnSides;
        }
    }
}
