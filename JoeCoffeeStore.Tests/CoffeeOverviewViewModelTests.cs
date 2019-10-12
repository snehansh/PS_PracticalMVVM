using JoeCoffeeStore.StockManagement.App.Services;
using JoeCoffeeStore.StockManagement.App.ViewModel;
using JoeCoffeeStore.StockManagement.Model;
using JoeCoffeeStore.Tests.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoeCoffeeStore.Tests
{
    [TestClass]
    public class CoffeeOverviewViewModelTests
    {
        private ICoffeeDataService _coffeeDataService;
        private IDialogService _dialogService;

        [TestInitialize]
        public void Init()
        {
            _coffeeDataService = new MockCoffeeDataService(new MockRepository());
            _dialogService = new MockDialogService();
        }

        [TestMethod]
        public void LoadAllCoffees()
        {
            //Arrange
            ObservableCollection<Coffee> coffees = null;
            var expectedCoffees = _coffeeDataService.GetAllCoffees();

            //Act
            var viewModel =
                new CoffeeOverviewViewModel(_coffeeDataService, _dialogService);
            coffees = viewModel.Coffees;

            //Assert
            CollectionAssert.AreEqual(expectedCoffees, coffees);
        }
    }
}
