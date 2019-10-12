using JoeCoffeeStore.StockManagement.App.Services;
using JoeCoffeeStore.StockManagement.DAL;
using JoeCoffeeStore.Tests.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoeCoffeeStore.Tests
{
    [TestClass]
    public class CoffeeDataServiceTest
    {
        private ICoffeeRepository repository;

        [TestInitialize]
        public void Init()
        {
            repository = new MockRepository();
        }

        [TestMethod]
        public void GetCoffeeDetailTest()
        {
            //arrange
            var service = new CoffeeDataService(repository);

            //act
            var coffee = service.GetCoffeeDetail(1);

            //assert
            Assert.IsNotNull(coffee);
        }
    }
}
