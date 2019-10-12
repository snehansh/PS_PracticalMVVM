using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace JoeCoffeeStore.StockManagement.Model
{
    public class Coffee: INotifyPropertyChanged
    {
        private int _coffeeId;
        private string _coffeeName;
        private int _price;

        public int CoffeeId
        {
            get
            {
                return _coffeeId;
            }
            set
            {
                _coffeeId = value;
                OnPropertyChanged();
            }
        }

        public string CoffeeName
        {
            get
            {
                return _coffeeName;
            }
            set
            {
                _coffeeName = value;
                OnPropertyChanged();
            }
        }

        public int Price
        {
            get
            {
                return _price;
            }
            set
            {
                _price = value;
                OnPropertyChanged();
            }
        }

        public string Description
        {
            get;
            set;
        }

        public Country OriginCountry
        {
            get;
            set;
        }

        public bool InStock
        {
            get;
            set;
        }

        public int AmountInStock 
        { 
            get; 
            set; 
        }

        public DateTime FirstAddedToStockDate
        {
            get;
            set;
        }

        public int ImageId
        {
            get;
            set;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
