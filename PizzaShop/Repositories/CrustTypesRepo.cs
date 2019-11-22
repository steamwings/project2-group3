using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaShop.Repositories
{
    public class CrustTypesRepo : IBasicRepo<CrustTypes>
    {
        private readonly Project2DatabaseContext _context;

        public CrustTypesRepo(Project2DatabaseContext ctx)
        {
            _context = ctx;
        }

        public IQueryable<CrustTypes> Get()
        {
            return _context.CrustTypes.Include(c => c.PriceCategory);
        }

        public async Task<CrustTypes> Get(int id)
        {
            return await _context.CrustTypes.Include(c => c.PriceCategory).Where(c => c.Id == id).FirstAsync();
        }

        public async Task<bool> Edit(CrustTypes CrustTypes)
        {
            _context.Entry(CrustTypes).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Add(CrustTypes CrustTypes)
        {
            _context.CrustTypes.Add(CrustTypes);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Remove(CrustTypes CrustTypes)
        {
            _context.CrustTypes.Remove(CrustTypes);
            await _context.SaveChangesAsync();
            return true;
        }

        public bool Exists(int id)
        {
            return _context.CrustTypes.Any(e => e.Id == id);
        }
    }
}
