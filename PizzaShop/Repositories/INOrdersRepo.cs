using Microsoft.EntityFrameworkCore;
using PizzaData.Models;
using System.Threading.Tasks;

namespace PizzaShop.Repositories
{
    public interface INOrdersRepo
    {
        DbSet<NOrders> Get();
        Task<NOrders> Get(int id);
        Task<bool> Add(NOrders NOrders);
        Task<bool> Add(OrderPizzas OrderPizzas);
        Task<bool> Add(OrderSides OrderSides);
        bool Exists(int id);
    }
}
