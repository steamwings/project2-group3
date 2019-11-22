using Microsoft.EntityFrameworkCore;
using PizzaData.Models;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaShop.Repositories
{
    public class SidesRepo : IBasicRepo<Sides>
    {
        private readonly Project2DatabaseContext _context;

        public SidesRepo(Project2DatabaseContext ctx)
        {
            _context = ctx;
        }

        public IQueryable<Sides> Get()
        {
            return _context.Sides.Include(s => s.PriceCategory);
        }

        public async Task<Sides> Get(int id)
        {
            return await _context.Sides.Include(s => s.PriceCategory).Where(s => s.Id == id).FirstAsync();
        }

        public async Task<bool> Edit(Sides Sides)
        {
            _context.Entry(Sides).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Add(Sides Sides)
        {
            _context.Sides.Add(Sides);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Remove(Sides Sides)
        {
            _context.Sides.Remove(Sides);
            await _context.SaveChangesAsync();
            return true;
        }

        public bool Exists(int id)
        {
            return _context.Sides.Any(e => e.Id == id);
        }
    }
}
