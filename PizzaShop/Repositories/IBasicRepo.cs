using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace PizzaShop.Repositories
{
    public interface IBasicRepo<T> where T : class
    {
        DbSet<T> Get();
        Task<T> Get(int id);
        Task<bool> Edit(T input);
        Task<bool> Add(T input);
        Task<bool> Remove(T input);
        bool Exists(int id);
    }
}
