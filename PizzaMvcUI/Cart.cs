﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaData.Models;
using PizzaMvcUI.Extensions;
using PizzaMvcUI.Models;
using PizzaMvcUI.Utilities;

namespace PizzaMvcUI
{
    public class Cart
    {
        public List<Pizzas> Pizzas { get; set; }
        public List<int> PrebuiltPizzas { get; set; }
        public List<int> Sides { get; set; }
        public Pizzas currentPizza;

        public async Task<List<Item>> GetItems()
        {
            List<Item> list = new List<Item>();
            //TODO: list.AddRange(await PrebuiltPizzas.Select(async p => await ItemFormatter.GetItemFromPizzaId(p)).WhenAll());
            list.AddRange(await Pizzas.Select(async p => await ItemFormatter.GetItem(p)).WhenAll());
            list.AddRange(await Sides.Select(async s => await ItemFormatter.GetItemFromSideId(s)).WhenAll());
            if (list.Count == 0) { list.Add(ItemFormatter.EmptyItem()); }
            return list;
        }

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
            /*
            var match = Sides.FirstOrDefault(x => x.Name == sideToRemove);

            if (match != null)
                Sides.Remove(match);
            */
            Sides.Remove(sideToRemove);
        }

    }
}
