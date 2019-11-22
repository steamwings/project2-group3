using Microsoft.EntityFrameworkCore;
using PizzaData.Models;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaShop.Repositories
{
    public class NPizzasRepo : INPizzasRepo
    {
        private readonly Project2DatabaseContext _context;

        public NPizzasRepo(Project2DatabaseContext ctx)
        {
            _context = ctx;
        }

        public IQueryable<NPizzas> Get()
        {
            return _context.NPizzas;
        }

        public async Task<NPizzas> Get(int id)
        {
            return await _context.NPizzas.FindAsync(id);
        }

        public async Task<bool> Edit(NPizzas NPizzas)
        {
            _context.Entry(NPizzas).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Add(NPizzas NPizzas)
        {
            _context.NPizzas.Add(NPizzas);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> Add(PizzaToppings PizzaToppings)
        {
            _context.PizzaToppings.Add(PizzaToppings);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Remove(NPizzas NPizzas)
        {
            _context.NPizzas.Remove(NPizzas);
            await _context.SaveChangesAsync();
            return true;
        }

        public bool Exists(int id)
        {
            return _context.NPizzas.Any(e => e.Id == id);
        }
    }
}
