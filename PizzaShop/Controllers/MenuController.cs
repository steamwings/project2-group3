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
                Cheeses = ConvertToVM(await _cheeseRepo.Get().ToListAsync()),
                Crusts = ConvertToVM(await _crustRepo.Get().ToListAsync()),
                Sauces = ConvertToVM(await _sauceRepo.Get().ToListAsync()),
                Sides = ConvertToVM(await _sideRepo.Get().ToListAsync()),
                Toppings = ConvertToVM(await _toppingRepo.Get().ToListAsync())
            };
        }


        public List<CheeseTypesVM> ConvertToVM(List<CheeseTypes> cheeseTypes)
        {
            List<CheeseTypesVM> returnCheeses = new List<CheeseTypesVM>();
            foreach (var item in cheeseTypes)
            {
                returnCheeses.Add(new CheeseTypesVM
                {
                    Id = item.Id,
                    Name = item.Name,
                    Description = item.Description,
                    Price = item.PriceCategory.Price
                });
            }
            return returnCheeses;
        }
        public List<CrustTypesVM> ConvertToVM(List<CrustTypes> cheeseTypes)
        {
            List<CrustTypesVM> returnCrusts = new List<CrustTypesVM>();
            foreach (var item in cheeseTypes)
            {
                returnCrusts.Add(new CrustTypesVM
                {
                    Id = item.Id,
                    Name = item.Name,
                    Description = item.Description,
                    Price = item.PriceCategory.Price
                });
            }
            return returnCrusts;
        }
        public List<SauceTypesVM> ConvertToVM(List<SauceTypes> sauceTypes)
        {
            List<SauceTypesVM> returnSauces = new List<SauceTypesVM>();
            foreach (var item in sauceTypes)
            {
                returnSauces.Add(new SauceTypesVM
                {
                    Id = item.Id,
                    Name = item.Name,
                    Description = item.Description,
                    Price = item.PriceCategory.Price
                });
            }
            return returnSauces;
        }
        public List<SidesVM> ConvertToVM(List<Sides> sauceTypes)
        {
            List<SidesVM> returnSides = new List<SidesVM>();
            foreach (var item in sauceTypes)
            {
                returnSides.Add(new SidesVM
                {
                    Id = item.Id,
                    Name = item.Name,
                    Description = item.Description,
                    Price = item.PriceCategory.Price
                });
            }
            return returnSides;
        }
        public List<ToppingsVM> ConvertToVM(List<Toppings> sauceTypes)
        {
            List<ToppingsVM> returnToppings = new List<ToppingsVM>();
            foreach (var item in sauceTypes)
            {
                returnToppings.Add(new ToppingsVM
                {
                    Id = item.Id,
                    Name = item.Name,
                    Description = item.Description,
                    Price = item.PriceCategory.Price
                });
            }
            return returnToppings;
        }
    }
}