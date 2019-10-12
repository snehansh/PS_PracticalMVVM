using JoeCoffeeStore.StockManagement.App.Messages;
using JoeCoffeeStore.StockManagement.App.Services;
using JoeCoffeeStore.StockManagement.App.Utility;
using JoeCoffeeStore.StockManagement.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace JoeCoffeeStore.StockManagement.App.ViewModel
{
    public class CoffeeDetailViewModel : INotifyPropertyChanged
    {
        private ICoffeeDataService _coffeeDataService;
        private IDialogService _dialogService;

        //public CoffeeDetailViewModel()
        public CoffeeDetailViewModel(ICoffeeDataService coffeeDataService, IDialogService dialogService)
        {
            //_coffeeDataService = new CoffeeDataService();

            _coffeeDataService = coffeeDataService;
            _dialogService = dialogService;

            SaveCommand = new CustomCommand(SaveCoffee, CanSaveCoffee);
            DeleteCommand = new CustomCommand(DeleteCoffee, CanDeleteCoffee);

            Messenger.Default.Register<Coffee>(this, OnCoffeeReceived);
        }

        private void OnCoffeeReceived(Coffee coffee)
        {
            SelectedCoffee = coffee;
        }

        private Coffee _selectedCoffee;
        public Coffee SelectedCoffee
        {
            get
            {
                return _selectedCoffee;
            }
            set
            {
                _selectedCoffee = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public ICommand SaveCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        private bool CanSaveCoffee(object obj)
        {
            return true;
        }

        private void SaveCoffee(object obj)
        {
            _coffeeDataService.UpdateCoffee(SelectedCoffee);
            Messenger.Default.Send<UpdateListMessage>(new UpdateListMessage());
        }

        private bool CanDeleteCoffee(object obj)
        {
            return true;
        }

        private void DeleteCoffee(object obj)
        {
            _coffeeDataService.DeleteCoffee(SelectedCoffee);
            Messenger.Default.Send<UpdateListMessage>(new UpdateListMessage());
        }

    }
}
