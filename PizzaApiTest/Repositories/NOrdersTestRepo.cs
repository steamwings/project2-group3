using Microsoft.EntityFrameworkCore;
using PizzaData.Models;
using PizzaShop.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaApiTest.Repositories
{
    class NOrdersTestRepo : INOrdersRepo
    {
        public Task<bool> Add(NOrders NOrders)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Add(OrderPizzas OrderPizzas)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Add(OrderSides OrderSides)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Add(OrderPreMadePizzas OrderPreMadePizzas)
        {
            throw new NotImplementedException();
        }

        public bool Exists(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<NOrders> Get()
        {
            throw new NotImplementedException();
        }

        public Task<NOrders> Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}
