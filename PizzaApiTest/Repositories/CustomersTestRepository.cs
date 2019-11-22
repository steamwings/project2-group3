using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PizzaData.Models;
using PizzaShop.Repositories;

namespace PizzaApiTest.Repositories
{
    class CustomersTestRepo : ICustomersRepo
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

        public bool Exists(string email)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<Customers> Get()
        {
            throw new System.NotImplementedException();
        }

        public Task<Customers> Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Customers> Login(LoginCredentials loginCredentials)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Remove(Customers Customers)
        {
            throw new System.NotImplementedException();
        }
    }
}
