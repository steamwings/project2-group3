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
    public class PreMadePizzasController : ControllerBase
    {
        private readonly IBasicRepo<PreMadePizzas> _repo;

        public PreMadePizzasController(IBasicRepo<PreMadePizzas> repo)
        {
            _repo = repo;
        }

        // GET: api/PreMadePizzas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PreMadePizzasVM>>> GetPreMadePizzas()
        {
            return ConvertToVM(await _repo.Get().ToListAsync());
        }

        // GET: api/PreMadePizzas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PreMadePizzasVM>> GetPreMadePizzas(int id)
        {
            var PreMadePizzas = await _repo.Get(id);

            if (PreMadePizzas == null)
            {
                return NotFound();
            }

            return ConvertToVM(PreMadePizzas);
        }

        // PUT: api/PreMadePizzas/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPreMadePizzas(int id, PreMadePizzas PreMadePizzas)
        {
            if (id != PreMadePizzas.Id)
            {
                return BadRequest();
            }

            try
            {
                await _repo.Edit(PreMadePizzas);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PreMadePizzasExists(id))
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

        // POST: api/PreMadePizzas
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<PreMadePizzas>> PostPreMadePizzas(PreMadePizzas PreMadePizzas)
        {

            await _repo.Add(PreMadePizzas);

            return CreatedAtAction("GetPreMadePizzas", new { id = PreMadePizzas.Id }, PreMadePizzas);
        }

        // DELETE: api/PreMadePizzas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PreMadePizzasVM>> DeletePreMadePizzas(int id)
        {
            var PreMadePizzas = await _repo.Get(id);
            if (PreMadePizzas == null)
            {
                return NotFound();
            }

            await _repo.Remove(PreMadePizzas);

            return ConvertToVM(PreMadePizzas);
        }

        private bool PreMadePizzasExists(int id)
        {
            return _repo.Exists(id);
        }



        public PreMadePizzasVM ConvertToVM(PreMadePizzas PreMadePizzas)
        {
            PreMadePizzasVM returnPMP = new PreMadePizzasVM
            {
                Id = PreMadePizzas.Id,
                Name = PreMadePizzas.Name,
                Description = PreMadePizzas.Description,
                Price = PreMadePizzas.PriceCategory.Price
            };

            return returnPMP;
        }

        public List<PreMadePizzasVM> ConvertToVM(List<PreMadePizzas> PMPizzas)
        {
            List<PreMadePizzasVM> returnPreMadePizzas = new List<PreMadePizzasVM>();
            foreach (var item in PMPizzas)
            {
                returnPreMadePizzas.Add(ConvertToVM(item));
            }
            return returnPreMadePizzas;
        }
    }
}
