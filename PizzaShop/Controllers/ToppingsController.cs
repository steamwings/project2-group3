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
    public class ToppingsController : ControllerBase
    {
        private readonly IBasicRepo<Toppings> _repo;

        public ToppingsController(IBasicRepo<Toppings> repo)
        {
            _repo = repo;
        }

        // GET: api/Toppings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToppingsVM>>> GetToppings()
        {
            return ConvertToVM(await _repo.Get().ToListAsync());
        }

        // GET: api/Toppings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ToppingsVM>> GetToppings(int id)
        {
            var toppings = await _repo.Get(id);

            if (toppings == null)
            {
                return NotFound();
            }

            return ConvertToVM(toppings);
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

            try
            {
                await _repo.Edit(toppings);
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
            
            await _repo.Add(toppings);

            return CreatedAtAction("GetToppings", new { id = toppings.Id }, toppings);
        }

        // DELETE: api/Toppings/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ToppingsVM>> DeleteToppings(int id)
        {
            var toppings = await _repo.Get(id);
            if (toppings == null)
            {
                return NotFound();
            }

            await _repo.Remove(toppings);

            return ConvertToVM(toppings);
        }

        private bool ToppingsExists(int id)
        {
            return _repo.Exists(id);
        }



        public ToppingsVM ConvertToVM(Toppings sides)
        {
            ToppingsVM returnTopping = new ToppingsVM
            {
                Id = sides.Id,
                Name = sides.Name,
                Description = sides.Description,
                Price = sides.PriceCategory.Price
            };

            return returnTopping;
        }

        public List<ToppingsVM> ConvertToVM(List<Toppings> sauceTypes)
        {
            List<ToppingsVM> returnToppings = new List<ToppingsVM>();
            foreach (var item in sauceTypes)
            {
                returnToppings.Add(ConvertToVM(item));
            }
            return returnToppings;
        }
    }
}
