using JoeCoffeeStore.StockManagement.App.Services;
using JoeCoffeeStore.StockManagement.DAL;
using JoeCoffeeStore.StockManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoeCoffeeStore.Tests.Mocks
{
    public class MockCoffeeDataService : ICoffeeDataService
    {
        private ICoffeeRepository _repository;
        public MockCoffeeDataService(ICoffeeRepository repository)
        {
            _repository = repository;
        }

        public void DeleteCoffee(Coffee coffee)
        {

        }

        public List<Coffee> GetAllCoffees()
        {
            return _repository.GetCoffees();
        }

        public Coffee GetCoffeeDetail(int coffeeId)
        {
            return _repository.GetCoffeeById(coffeeId);
        }

        public void UpdateCoffee(Coffee coffee)
        {

        }
    }
}
