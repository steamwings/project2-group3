using NUnit.Framework;
using PizzaMvcUI.Utilities;

namespace PizzaMVCTest
{
    public class HashTest
    {
        [Test]
        public void Test1()
        {
            var hash = HashHelper.HashWithExistingSalt("TestPassword", "/UPFI3UrZUm5tiKwCiqycA==");
            Assert.AreEqual("dx7mcG9340WPzZ9ogu9enPfvZ+rMvPFNTjvfNcadyxU=", hash);
        }

        [Test]
        public void Test2()
        {
            var pass = "Password123";
            var passHash1 = HashHelper.HashWithNewSalt(pass, out string salt);
            var passHash2 = HashHelper.HashWithExistingSalt(pass, salt);
            Assert.AreEqual(passHash1, passHash2);
        }
    }
}
