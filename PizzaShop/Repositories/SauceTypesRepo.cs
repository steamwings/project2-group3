using Microsoft.EntityFrameworkCore;
using PizzaData.Models;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaShop.Repositories
{
    public class SauceTypesRepo : IBasicRepo<SauceTypes>
    {
        private readonly Project2DatabaseContext _context;

        public SauceTypesRepo(Project2DatabaseContext ctx)
        {
            _context = ctx;
        }

        public IQueryable<SauceTypes> Get()
        {
            return _context.SauceTypes.Include(s => s.PriceCategory);
        }

        public async Task<SauceTypes> Get(int id)
        {
            return await _context.SauceTypes.Include(s => s.PriceCategory).Where(s => s.Id == id).FirstAsync();
        }

        public async Task<bool> Edit(SauceTypes SauceTypes)
        {
            _context.Entry(SauceTypes).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Add(SauceTypes SauceTypes)
        {
            _context.SauceTypes.Add(SauceTypes);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Remove(SauceTypes SauceTypes)
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
