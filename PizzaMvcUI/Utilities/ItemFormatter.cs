using PizzaData.Models;
using PizzaMvcUI.Models;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMvcUI.Utilities
{
    public static class ItemFormatter
    {
        public static string Format(decimal price)
        {
            return "$" + price.ToString("C");
        }

        public static async Task<Item> GetItem(Pizzas p)
        {
            var menu = await API.GetMenu();
            StringBuilder desc = new StringBuilder();

            desc.Append(menu.Crusts.Where(c => c.Id == p.CrustTypesId).Single().Name);
            desc.Append(" Crust, ");
            desc.Append(menu.Sauces.Where(s => s.Id == p.SauceTypesId).Single().Name);
            desc.Append(" Sauce, ");
            desc.Append(menu.Cheeses.Where(c => c.Id == p.CheeseTypesId).Single().Name);
            desc.Append(" Cheese");
            p.ToppingsId?.ForEach(tid =>
            {
                desc.Append(", ");
                desc.Append(menu.Toppings.Where(t => t.Id == tid).Single().Name);
            });

            return new Item() { Name = "Custom Pizza", Description = desc.ToString(), Price = Format(p.Price) };
        }

        public static async Task<Item> GetItemFromSideId(int sideId)
        {
            var menu = await API.GetMenu();
            var side = menu.Sides.Where(s => s.Id == sideId).Single();
            return new Item() { Id= side.Id, Name = side.Name, Description = side.Description, Price = Format(side.Price) };
        }
        public static async Task<Item> GetItemFromPizzaId(int pizzaId)
        {
            var menu = await API.GetMenu();
            var pMPizza = menu.PreMadePizzas.Where(p => p.Id == pizzaId).Single();
            return new Item() { Id = pMPizza.Id, Name = pMPizza.Name, Description = pMPizza.Description, Price = Format(pMPizza.Price) };
        }

        public static Item EmptyItem()
        {
            return new Item { Name = "No Items to Display", Description = "-", Price = "-" };
        }
    }
}
