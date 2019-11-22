using Microsoft.EntityFrameworkCore;
using PizzaData.Models;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaShop.Repositories
{
    public class CustomersRepo
    {
        private readonly Project2DatabaseContext _context;

        public CustomersRepo(Project2DatabaseContext ctx)
        {
            _context = ctx;
        }

        public DbSet<Customers> Get()
        {
            return _context.Customers;
        }

        public async Task<Customers> Get(int id)
        {
            return await _context.Customers.FindAsync(id);
        }

        public async Task<bool> Edit(Customers Customers)
        {
            _context.Entry(Customers).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Add(Customers Customers)
        {
            _context.Customers.Add(Customers);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Remove(Customers Customers)
        {
            _context.Customers.Remove(Customers);
            await _context.SaveChangesAsync();
            return true;
        }

        public bool Exists(int id)
        {
            return _context.Customers.Any(e => e.Id == id);
        }
        public bool Exists(string email)
        {
            return _context.Customers.Any(c => c.Email == email);
        }

        public async Task<Customers> Login(LoginCredentials loginCredentials)
        {
            return await _context.Customers
                .Where(cust => cust.Email == loginCredentials.Email && cust.PasswordHash == loginCredentials.PasswordHash)
                .SingleOrDefaultAsync();
        }

    }
}
