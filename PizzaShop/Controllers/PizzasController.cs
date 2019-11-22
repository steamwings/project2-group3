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
    public class PizzasController : ControllerBase
    {
        private readonly INPizzasRepo _repo;

        public PizzasController(INPizzasRepo repo)
        {
            _repo = repo;
        }

        // GET: api/Pizzas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NPizzas>>> GetPizzas()
        {
            return await _repo.Get().ToListAsync();
        }

        // GET: api/Pizzas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NPizzas>> GetPizzas(int id)
        {
            var pizzas = await _repo.Get(id);

            if (pizzas == null)
            {
                return NotFound();
            }

            return pizzas;
        }

        // PUT: api/Pizzas/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPizzas(int id, NPizzas pizzas)
        {
            if (id != pizzas.Id)
            {
                return BadRequest();
            }

            try
            {
                await _repo.Edit(pizzas);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PizzasExists(id))
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

        // POST: api/Pizzas
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<NPizzas>> PostPizzas(NPizzas pizzas)
        {
            
            await _repo.Add(pizzas);

            return CreatedAtAction("GetPizzas", new { id = pizzas.Id }, pizzas);
        }

        // DELETE: api/Pizzas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<NPizzas>> DeletePizzas(int id)
        {
            var pizzas = await _repo.Get(id);
            if (pizzas == null)
            {
                return NotFound();
            }

            await _repo.Remove(pizzas);

            return pizzas;
        }

        private bool PizzasExists(int id)
        {
            return _repo.Exists(id);
        }
    }
}
