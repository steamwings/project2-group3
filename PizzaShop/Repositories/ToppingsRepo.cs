using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaShop.Repositories
{
    public class ToppingsRepo
    {
        private readonly Project2DatabaseContext _context;

        public ToppingsRepo(Project2DatabaseContext ctx)
        {
            _context = ctx;
        }

        public DbSet<Toppings> Get()
        {
            return _context.Toppings;
        }

        public async Task<Toppings> Get(int id)
        {
            return await _context.Toppings.FindAsync(id);
        }

        public async Task<bool> Edit(Toppings Toppings)
        {
            _context.Entry(Toppings).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Add(Toppings Toppings)
        {
            _context.Toppings.Add(Toppings);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Remove(Toppings Toppings)
        {
            _context.Toppings.Remove(Toppings);
            await _context.SaveChangesAsync();
            return true;
        }

        public bool Exists(int id)
        {
            return _context.Toppings.Any(e => e.Id == id);
        }
    }
}
