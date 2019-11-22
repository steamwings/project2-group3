using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PizzaData.Models;
using PizzaShop.Repositories;

namespace PizzaApiTest.Repositories
{
    class CustomersTestRepository : ICustomersRepo
    {
        public Task<bool> Add(Customers Customers)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Edit(Customers Customers)
        {
            throw new System.NotImplementedException();
        }

        public bool Exists(int id)
        {
            throw new System.NotImplementedException();
        }

        public DbSet<Customers> Get()
        {
            throw new System.NotImplementedException();
        }

        public Task<Customers> Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Remove(Customers Customers)
        {
            throw new System.NotImplementedException();
        }
    }
}
