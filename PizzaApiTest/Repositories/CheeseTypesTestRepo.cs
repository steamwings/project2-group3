using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PizzaData.Models;
using PizzaShop.Repositories;

namespace PizzaApiTest.Repositories
{
    class CheeseTypesTestRepo : IBasicRepo<CheeseTypes>
    {
        public List<CheeseTypes> CheeseTypes = new List<CheeseTypes>();
        public async Task<bool> Add(CheeseTypes input)
        {
            CheeseTypes.Add(input);
            return true;
        }

        public async Task<bool> Edit(CheeseTypes input)
        {
            var cheese = await Get(input.Id);
            if (cheese is null)
            {
                throw new DbUpdateConcurrencyException();
            }
            int index = CheeseTypes.FindIndex(c => c.Id == input.Id);
            CheeseTypes[index] = input;
            return true;
        }

        public bool Exists(int id)
        {
            return CheeseTypes.Any(e => e.Id == id);
        }

        public IQueryable<CheeseTypes> Get()
        {
            throw new System.NotImplementedException();
        }

        public async Task<CheeseTypes> Get(int id)
        {
            try
            {
                return CheeseTypes.Where(cheese => cheese.Id == id).First();
            }catch (InvalidOperationException)
            {
                return null;
            }
        }

        public async Task<bool> Remove(CheeseTypes input)
        {
            CheeseTypes.Remove(input);
            return true;
        }
    }
}
