using Microsoft.EntityFrameworkCore;
using PizzaData.Models;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaShop.Repositories
{
    public class PreMadePizzasRepo : IBasicRepo<PreMadePizzas>
    {
        private readonly Project2DatabaseContext _context;

        public PreMadePizzasRepo(Project2DatabaseContext ctx)
        {
            _context = ctx;
        }

        public IQueryable<PreMadePizzas> Get()
        {
            return _context.PreMadePizzas.Include(pmp => pmp.PriceCategory);
        }

        public async Task<PreMadePizzas> Get(int id)
        {
            return await _context.PreMadePizzas.Include(pmp => pmp.PriceCategory).Where(pmp => pmp.Id == id).FirstAsync();
        }

        public async Task<bool> Edit(PreMadePizzas PMPizzas)
        {
            _context.Entry(PMPizzas).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Add(PreMadePizzas PMPizzas)
        {
            _context.PreMadePizzas.Add(PMPizzas);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Remove(PreMadePizzas PMPizzas)
        {
            _context.PreMadePizzas.Remove(PMPizzas);
            await _context.SaveChangesAsync();
            return true;
        }

        public bool Exists(int id)
        {
            return _context.PreMadePizzas.Any(e => e.Id == id);
        }
    }
}
