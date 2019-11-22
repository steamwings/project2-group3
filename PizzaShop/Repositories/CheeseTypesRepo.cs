using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaShop.Repositories
{
    public class CheeseTypesRepo : IBasicRepo<CheeseTypes>
    {
        private readonly Project2DatabaseContext _context;

        public CheeseTypesRepo(Project2DatabaseContext ctx)
        {
            _context = ctx;
        }

        public DbSet<CheeseTypes> Get()
        {
            return _context.CheeseTypes;
        }

        public async Task<CheeseTypes> Get(int id)
        {
            return await _context.CheeseTypes.FindAsync(id);
        }

        public async Task<bool> Edit(CheeseTypes cheeseTypes)
        {
            _context.Entry(cheeseTypes).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Add(CheeseTypes cheeseTypes)
        {
            _context.CheeseTypes.Add(cheeseTypes);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Remove(CheeseTypes cheeseTypes)
        {
            _context.CheeseTypes.Remove(cheeseTypes);
            await _context.SaveChangesAsync();
            return true;
        }

        public bool Exists(int id)
        {
            return _context.CheeseTypes.Any(e => e.Id == id);
        }
    }
}
