using JoeCoffeeStore.StockManagement.App.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace JoeCoffeeStore.StockManagement.App.Services
{
    public interface IDialogService
    {
        void ShowDialog();
        void CloseDialog();
    }
}
