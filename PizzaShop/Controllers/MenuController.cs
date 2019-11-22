using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaData.Models;
using PizzaShop.Repositories;

namespace PizzaShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IBasicRepo<CrustTypes> _crustRepo;
        private readonly IBasicRepo<CheeseTypes> _cheeseRepo;
        private readonly IBasicRepo<SauceTypes> _sauceRepo;
        private readonly IBasicRepo<Toppings> _toppingRepo;
        private readonly IBasicRepo<Sides> _sideRepo;

        public MenuController(IBasicRepo<CrustTypes> crustRepo, IBasicRepo<CheeseTypes> cheeseRepo,
            IBasicRepo<SauceTypes> sauceRepo, IBasicRepo<Toppings> toppingRepo, IBasicRepo<Sides> sideRepo)
        {
            _crustRepo = crustRepo;
            _cheeseRepo = cheeseRepo;
            _sauceRepo = sauceRepo;
            _toppingRepo = toppingRepo;
            _sideRepo = sideRepo;
        }

        // GET: api/Menu
        [HttpGet]
        public async Task<ActionResult<Menu>> GetMenu()
        {
            return new Menu()
            {
                Cheeses = await _cheeseRepo.Get().ToListAsync(),
                Crusts = await _crustRepo.Get().ToListAsync(),
                Sauces = await _sauceRepo.Get().ToListAsync(),
                Sides = await _sideRepo.Get().ToListAsync(),
                Toppings = await _toppingRepo.Get().ToListAsync()
            };
        }
    }
}