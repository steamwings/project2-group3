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
        private readonly CrustTypesRepo _crustRepo;
        private readonly CheeseTypesRepo _cheeseRepo;
        private readonly SauceTypesRepo _sauceRepo;
        private readonly ToppingsRepo _toppingRepo;
        private readonly SidesRepo _sideRepo;

        public MenuController(CrustTypesRepo crustRepo, CheeseTypesRepo cheeseRepo,
            SauceTypesRepo sauceRepo, ToppingsRepo toppingRepo, SidesRepo sideRepo)
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