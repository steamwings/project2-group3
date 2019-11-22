using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PizzaData.Models;
using PizzaShop.Repositories;

namespace PizzaApiTest.Repositories
{
    class CheeseTypesTestRepository : IBasicRepo<CheeseTypes>
    {
        public Task<bool> Add(CheeseTypes input)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Edit(CheeseTypes input)
        {
            throw new System.NotImplementedException();
        }

        public bool Exists(int id)
        {
            throw new System.NotImplementedException();
        }

        public DbSet<CheeseTypes> Get()
        {
            throw new System.NotImplementedException();
        }

        public Task<CheeseTypes> Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Remove(CheeseTypes input)
        {
            throw new System.NotImplementedException();
        }
    }
}
