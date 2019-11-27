using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using PizzaMvcUI.Controllers;

namespace PizzaMVCTest
{
    public class CustomerTest
    {
        [SetUp]
        public void Setup()
        {        }

        [Test]
        public void Test1()
        {
            var controller = new CustomersController();
            var result = controller.LogIn() as ViewResult;
            Assert.AreEqual("Login", result.ViewName);
        }
    }
}