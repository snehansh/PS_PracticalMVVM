using JoeCoffeeStore.StockManagement.App.Extensions;
using JoeCoffeeStore.StockManagement.App.Messages;
using JoeCoffeeStore.StockManagement.App.Services;
using JoeCoffeeStore.StockManagement.App.Utility;
using JoeCoffeeStore.StockManagement.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace JoeCoffeeStore.StockManagement.App.ViewModel
{
    public class CoffeeOverviewViewModel : INotifyPropertyChanged
    {
        //private CoffeeDataService _coffeeDataService;
        //private DialogService _dialogService;

        private ICoffeeDataService _coffeeDataService;
        private IDialogService _dialogService;

        //public CoffeeOverviewViewModel()
        public CoffeeOverviewViewModel(ICoffeeDataService coffeeDataService, IDialogService dialogService)
        {
            //_coffeeDataService = new CoffeeDataService();
            //_dialogService = new DialogService();

            _coffeeDataService = coffeeDataService;
            _dialogService = dialogService;

            LoadData();
            LoadCommands();

            Messenger.Default.Register<UpdateListMessage>(this, OnUpdateListMessageReceived);
        }

        private void OnUpdateListMessageReceived(UpdateListMessage obj)
        {
            LoadData();
            _dialogService.CloseDialog();
        }

        private void LoadData()
        {
            Coffees = _coffeeDataService.GetAllCoffees().ToObservableCollection();
        }

        private ObservableCollection<Coffee> _coffees;
        public ObservableCollection<Coffee> Coffees
        {
            get
            {
                return _coffees;
            }
            set
            {
                _coffees = value;
                OnPropertyChanged();
            }
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

        public ICommand EditCommand { get; set; }

        private void LoadCommands()
        {
            EditCommand = new CustomCommand(EditCoffee, CanEditCoffee);
        }

        private void EditCoffee(object obj)
        {
            Messenger.Default.Send<Coffee>(_selectedCoffee);
            _dialogService.ShowDialog();
        }

        private bool CanEditCoffee(object obj)
        {
            if (SelectedCoffee != null)
                return true;
            return false;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
