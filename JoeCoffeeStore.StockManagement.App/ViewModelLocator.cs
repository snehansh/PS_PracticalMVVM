using JoeCoffeeStore.StockManagement.App.Services;
using JoeCoffeeStore.StockManagement.App.ViewModel;
using JoeCoffeeStore.StockManagement.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoeCoffeeStore.StockManagement.App
{
    public class ViewModelLocator
    {
        //private static CoffeeOverviewViewModel _coffeeOverviewViewModel = new CoffeeOverviewViewModel();
        //private static CoffeeDetailViewModel _coffeeDetailViewModel = new CoffeeDetailViewModel();

        private static IDialogService _dialogService =
            new DialogService();

        private static ICoffeeDataService _coffeeDataService =
            new CoffeeDataService(new CoffeeRepository());

        private static CoffeeOverviewViewModel _coffeeOverviewViewModel =
            new CoffeeOverviewViewModel(_coffeeDataService, _dialogService);
        private static CoffeeDetailViewModel _coffeeDetailViewModel =
            new CoffeeDetailViewModel(_coffeeDataService, _dialogService);

        public static CoffeeDetailViewModel CoffeeDetailViewModel
        {
            get
            {
                return _coffeeDetailViewModel;
            }
        }

        public static CoffeeOverviewViewModel CoffeeOverviewViewModel
        {
            get
            {
                return _coffeeOverviewViewModel;
            }
        }
    }
}
