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
        Task<Customers> Login(LoginCredentials loginCredentials);
        bool Exists(int id);
        bool Exists(string email);
    }
}
