using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PizzaApiTest.Repositories;
using PizzaData.Models;
using PizzaShop.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaApiTest.CheeseTypesTests
{
    [TestClass]
    public class TestPutCheeseTypes
    {

        [TestMethod]
        public void EditValidCheeseType()
        {
            var repo = new CheeseTypesTestRepo();
            repo.CheeseTypes.Add(new CheeseTypes { Id = 1, Name = "Mozzarella", Description = "Pizza Cheese" });
            var controller = new CheeseTypesController(repo);
            var cheeseToEdit = new CheeseTypes { Id = 1, Name = "Cheddar", Description = "Orange Cheese" };

            var result = controller.PutCheeseTypes(1,cheeseToEdit);

            Assert.IsInstanceOfType(result.Result, typeof(NoContentResult));
        }

        [TestMethod]
        public void CheeseTypeNotFoundTest()
        {
            var repo = new CheeseTypesTestRepo();
            repo.CheeseTypes.Add(new CheeseTypes { Id = 1, Name = "Mozzarella", Description = "Pizza Cheese" });
            var controller = new CheeseTypesController(repo);
            var cheeseToEdit = new CheeseTypes { Id = 2, Name = "Cheddar", Description = "Orange Cheese" };

            var result = controller.PutCheeseTypes(2, cheeseToEdit);

            Assert.IsInstanceOfType(result.Result, typeof(NotFoundResult));
        }

        [TestMethod]
        public void BadRequestTest()
        {
            var repo = new CheeseTypesTestRepo();
            repo.CheeseTypes.Add(new CheeseTypes { Id = 1, Name = "Mozzarella", Description = "Pizza Cheese" });
            var controller = new CheeseTypesController(repo);
            var cheeseToEdit = new CheeseTypes { Id = 2, Name = "Cheddar", Description = "Orange Cheese" };

            var result = controller.PutCheeseTypes(3, cheeseToEdit);

            Assert.IsInstanceOfType(result.Result, typeof(BadRequestResult));
        }
    }
}