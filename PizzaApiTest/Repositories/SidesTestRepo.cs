using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PizzaData.Models;
using PizzaShop.Repositories;

namespace PizzaApiTest.Repositories
{
    class SidesTestRepo : IBasicRepo<Sides>
    {
        public Task<bool> Add(Sides input)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Edit(Sides input)
        {
            throw new System.NotImplementedException();
        }

        public bool Exists(int id)
        {
            throw new System.NotImplementedException();
        }

        public DbSet<Sides> Get()
        {
            throw new System.NotImplementedException();
        }

        public Task<Sides> Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Remove(Sides input)
        {
            throw new System.NotImplementedException();
        }
    }
}
