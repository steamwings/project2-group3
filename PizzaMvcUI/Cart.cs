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
        private Pizzas currentPizza;

        public void BuildPizza()
        {
            currentPizza = new Pizzas();
        }

        public void AddCrust(int id)
        {
            currentPizza.CrustTypesId = id;
        }

        public void AddSauce(int id)
        {
            currentPizza.SauceTypesId = id;
        }

        public void AddCheese(int id)
        {
            currentPizza.CheeseTypesId = id;
        }

        public void AddTopping(int id)
        {
            currentPizza.ToppingsId.Add(id);
        }

        public void AddPizza()
        {
            Pizzas newPizza = new Pizzas
            {
                CheeseTypesId = currentPizza.CheeseTypesId,
                CrustTypesId = currentPizza.CrustTypesId,
                SauceTypesId = currentPizza.SauceTypesId
            };
            foreach (var item in currentPizza.ToppingsId)
            {
                newPizza.ToppingsId.Add(item);
            }
            Pizzas.Add(newPizza);
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

        public bool CurrentPizzaIsNull()
        {
            if (currentPizza == null)
            {
                return true;
            } else
            {
                return false;
            }
        }

    }
}
