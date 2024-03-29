﻿using System;
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
        private readonly IBasicRepo<SauceTypes> _repo;

        public SauceTypesController(IBasicRepo<SauceTypes> repo)
        {
            _repo = repo;
        }

        // GET: api/SauceTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SauceTypesVM>>> GetSauceTypes()
        {
            return ConvertToVM(await _repo.Get().ToListAsync());
        }

        // GET: api/SauceTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SauceTypesVM>> GetSauceTypes(int id)
        {
            var sauceTypes = await _repo.Get(id);

            if (sauceTypes == null)
            {
                return NotFound();
            }

            return ConvertToVM(sauceTypes);
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
                await _repo.Edit(sauceTypes);
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
            
            await _repo.Add(sauceTypes);

            return CreatedAtAction("GetSauceTypes", new { id = sauceTypes.Id }, sauceTypes);
        }

        // DELETE: api/SauceTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SauceTypesVM>> DeleteSauceTypes(int id)
        {
            var sauceTypes = await _repo.Get(id);
            if (sauceTypes == null)
            {
                return NotFound();
            }

            
            await _repo.Remove(sauceTypes);

            return ConvertToVM(sauceTypes);
        }

        private bool SauceTypesExists(int id)
        {
            return _repo.Exists(id);
        }



        public SauceTypesVM ConvertToVM(SauceTypes sauceTypes)
        {
            SauceTypesVM returnSauce = new SauceTypesVM
            {
                Id = sauceTypes.Id,
                Name = sauceTypes.Name,
                Description = sauceTypes.Description,
                Price = sauceTypes.PriceCategory.Price
            };

            return returnSauce;
        }

        public List<SauceTypesVM> ConvertToVM(List<SauceTypes> sauceTypes)
        {
            List<SauceTypesVM> returnSauces = new List<SauceTypesVM>();
            foreach (var item in sauceTypes)
            {
                returnSauces.Add(ConvertToVM(item));
            }
            return returnSauces;
        }
    }
}
