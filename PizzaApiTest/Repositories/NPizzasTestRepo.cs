using Microsoft.EntityFrameworkCore;
using PizzaData.Models;
using PizzaShop.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PizzaApiTest.Repositories
{
    class NPizzasTestRepo : INPizzasRepo
    {
        public Task<bool> Add(PizzaToppings PizzaToppings)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Add(NPizzas input)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Edit(NPizzas input)
        {
            throw new NotImplementedException();
        }

        public bool Exists(int id)
        {
            throw new NotImplementedException();
        }

        public DbSet<NPizzas> Get()
        {
            throw new NotImplementedException();
        }

        public Task<NPizzas> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Remove(NPizzas input)
        {
            throw new NotImplementedException();
        }
    }
}
