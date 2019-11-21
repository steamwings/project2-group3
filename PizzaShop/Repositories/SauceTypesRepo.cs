using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaShop.Repositories
{
    public class SauceTypesRepo
    {
        private readonly Project2DatabaseContext _context;

        public SauceTypesRepo(Project2DatabaseContext ctx)
        {
            _context = ctx;
        }

        public DbSet<SauceTypes> Get()
        {
            return _context.SauceTypes;
        }

        public async Task<SauceTypes> Get(int id)
        {
            return await _context.SauceTypes.FindAsync(id);
        }

        public async Task<bool> Put(SauceTypes SauceTypes)
        {
            _context.Entry(SauceTypes).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Post(SauceTypes SauceTypes)
        {
            _context.SauceTypes.Add(SauceTypes);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(SauceTypes SauceTypes)
        {
            _context.SauceTypes.Remove(SauceTypes);
            await _context.SaveChangesAsync();
            return true;
        }

        public bool Exists(int id)
        {
            return _context.SauceTypes.Any(e => e.Id == id);
        }
    }
}
