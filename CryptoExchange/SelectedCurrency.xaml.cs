using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CryptoExchange
{
    /// <summary>
    /// Логика взаимодействия для SelectedCurrency.xaml
    /// </summary>
    public partial class SelectedCurrency : Page, INotifyPropertyChanged
    {
        private Currency _currencyResult;
        public Currency CurrencyResult
        {
            get { return _currencyResult; }
            set {_currencyResult = value;  OnPropertyChanged(); }
        }
        public SelectedCurrency(Currency currency)
        {
            InitializeComponent();
            CurrencyResult = currency;
            DataContext = this;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string property = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
    }
}
