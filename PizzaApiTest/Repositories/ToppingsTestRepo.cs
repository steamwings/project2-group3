using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PizzaData.Models;
using PizzaShop.Repositories;

namespace PizzaApiTest.Repositories
{
    class ToppingsTestRepo : IBasicRepo<Toppings>
    {
        public Task<bool> Add(Toppings input)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Edit(Toppings input)
        {
            throw new System.NotImplementedException();
        }

        public bool Exists(int id)
        {
            throw new System.NotImplementedException();
        }

        public DbSet<Toppings> Get()
        {
            throw new System.NotImplementedException();
        }

        public Task<Toppings> Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Remove(Toppings input)
        {
            throw new System.NotImplementedException();
        }
    }
}
