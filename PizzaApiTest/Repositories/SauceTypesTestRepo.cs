using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PizzaData.Models;
using PizzaShop.Repositories;

namespace PizzaApiTest.Repositories
{
    class SauceTypesTestRepository : IBasicRepo<SauceTypes>
    {
        public Task<bool> Add(SauceTypes input)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Edit(SauceTypes input)
        {
            throw new System.NotImplementedException();
        }

        public bool Exists(int id)
        {
            throw new System.NotImplementedException();
        }

        public DbSet<SauceTypes> Get()
        {
            throw new System.NotImplementedException();
        }

        public Task<SauceTypes> Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Remove(SauceTypes input)
        {
            throw new System.NotImplementedException();
        }
    }
}
