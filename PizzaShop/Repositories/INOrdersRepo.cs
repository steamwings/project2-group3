using Microsoft.EntityFrameworkCore;
using PizzaData.Models;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaShop.Repositories
{
    public interface INOrdersRepo
    {
        IQueryable<NOrders> Get();
        Task<NOrders> Get(int id);
        IQueryable<NOrders> GetByCustomerId(int id);
        Task<bool> Add(NOrders NOrders);
        Task<bool> Add(OrderPizzas OrderPizzas);
        Task<bool> Add(OrderSides OrderSides);
        Task<bool> Add(OrderPreMadePizzas OrderPreMadePizzas);
        bool Exists(int id);
    }
}
