﻿using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PizzaData.Models;
using PizzaShop.Repositories;

namespace PizzaApiTest.Repositories
{
    class CrustTypesTestRepository : IBasicRepo<CrustTypes>
    {
        public Task<bool> Add(CrustTypes input)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Edit(CrustTypes input)
        {
            throw new System.NotImplementedException();
        }

        public bool Exists(int id)
        {
            throw new System.NotImplementedException();
        }

        public DbSet<CrustTypes> Get()
        {
            throw new System.NotImplementedException();
        }

        public Task<CrustTypes> Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Remove(CrustTypes input)
        {
            throw new System.NotImplementedException();
        }
    }
}
