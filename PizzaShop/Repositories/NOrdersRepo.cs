﻿using Microsoft.EntityFrameworkCore;
using PizzaData.Models;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaShop.Repositories
{
    public class NOrdersRepo : INOrdersRepo
    {
        private readonly Project2DatabaseContext _context;

        public NOrdersRepo(Project2DatabaseContext ctx)
        {
            _context = ctx;
        }

        public IQueryable<NOrders> Get()
        {
            return _context.NOrders;
        }

        public async Task<NOrders> Get(int id)
        {
            return await _context.NOrders.FindAsync(id);
        }

        public async Task<bool> Add(NOrders NOrders)
        {
            _context.NOrders.Add(NOrders);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> Add(OrderPizzas OrderPizzas)
        {
            _context.OrderPizzas.Add(OrderPizzas);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> Add(OrderSides OrderSides)
        {
            _context.OrderSides.Add(OrderSides);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> Add(OrderPreMadePizzas OrderPreMadePizzas)
        {
            _context.OrderPreMadePizzas.Add(OrderPreMadePizzas);
            await _context.SaveChangesAsync();
            return true;
        }

        public bool Exists(int id)
        {
            return _context.NOrders.Any(e => e.Id == id);
        }

        public IQueryable<NOrders> GetByCustomerId(int id)
        {
            return _context.NOrders
                .Include(order => order.OrderPizzas)
                    .ThenInclude(oPizzas => oPizzas.NPizza)
                        .ThenInclude(Pizza => Pizza.CheeseType)
                            .ThenInclude(Cheese => Cheese.PriceCategory)
                .Include(order => order.OrderPizzas)
                    .ThenInclude(oPizzas => oPizzas.NPizza)
                        .ThenInclude(Pizza => Pizza.CrustType)
                            .ThenInclude(Cheese => Cheese.PriceCategory)
                .Include(order => order.OrderPizzas)
                    .ThenInclude(oPizzas => oPizzas.NPizza)
                        .ThenInclude(Pizza => Pizza.SauceType)
                            .ThenInclude(Cheese => Cheese.PriceCategory)
                .Include(order => order.OrderPizzas)
                    .ThenInclude(oPizzas => oPizzas.NPizza)
                        .ThenInclude(Pizza => Pizza.PizzaToppings)
                            .ThenInclude(PToppings => PToppings.Topping)
                                .ThenInclude(Cheese => Cheese.PriceCategory)
                .Include(order => order.OrderPreMadePizzas)
                    .ThenInclude(oPizzas => oPizzas.PreMadePizza)
                        .ThenInclude(pmPizza => pmPizza.PriceCategory)
                .Include(order => order.OrderSides)
                    .ThenInclude(oSides => oSides.Side)
                        .ThenInclude(side => side.PriceCategory)
                .Where(o => o.CustomerId == id);
        }
    }
}
