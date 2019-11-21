using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaData.Models;

namespace PizzaMvcUI
{
    public class Cart
    {
        public List<Pizzas> Pizzas { get; set; }
        public List<int> Sides { get; set; }
        public Pizzas currentPizza;

        public void BuildPizza()
        {
            currentPizza = new Pizzas { ToppingsId = new List<int>() };
        }

        public void AddCrust(int id)
        {
            if (currentPizza is null) return;
            currentPizza.CrustTypesId = id;
        }

        public void AddSauce(int id)
        {
            if (currentPizza is null) return;
            currentPizza.SauceTypesId = id;
        }

        public void AddCheese(int id)
        {
            if (currentPizza is null) return;
            currentPizza.CheeseTypesId = id;
        }

        public void AddTopping(int id)
        {
            if (currentPizza is null) return;
            currentPizza.ToppingsId.Add(id);
        }

        public void AddPizza()
        {
            if (currentPizza is null) return;
            Pizzas.Add(currentPizza);
            currentPizza = null;
        }

        public void AddSide(int sideId)
        {
            Sides.Add(sideId);
        }

        public void RemovePizza(Pizzas pizzaToRemove)
        {
            Pizzas.Remove(pizzaToRemove);
        }

        public void RemoveSide(int sideToRemove)
        {
            Sides.Remove(sideToRemove);
        }

    }
}
