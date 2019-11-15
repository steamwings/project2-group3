using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaData.Models;

namespace PizzaShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly Project2DatabaseContext _context;

        public MenuController(Project2DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Menu
        [HttpGet]
        public async Task<ActionResult<Menu>> GetMenu()
        {
            return new Menu()
            {
                Cheeses = await _context.CheeseTypes.ToListAsync(),
                Crusts = await _context.CrustTypes.ToListAsync(),
                Sauces = await _context.SauceTypes.ToListAsync(),
                Sides = await _context.Sides.ToListAsync(),
                Toppings = await _context.Toppings.ToListAsync()
            };
        }
    }
}