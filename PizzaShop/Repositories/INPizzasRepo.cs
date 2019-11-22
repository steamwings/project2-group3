using PizzaData.Models;
using System.Threading.Tasks;

namespace PizzaShop.Repositories
{
    public interface INPizzasRepo : IBasicRepo<NPizzas>
    {
        Task<bool> Add(PizzaToppings PizzaToppings);
    }
}
