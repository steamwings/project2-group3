using Microsoft.EntityFrameworkCore;
using PizzaData.Models;
using System.Threading.Tasks;

namespace PizzaShop.Repositories
{
    public interface ICustomersRepo
    {
        DbSet<Customers> Get();
        Task<Customers> Get(int id);
        Task<bool> Edit(Customers Customers);
        Task<bool> Add(Customers Customers);
        Task<bool> Remove(Customers Customers);
        bool Exists(int id);
    }
}
