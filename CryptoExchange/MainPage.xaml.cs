using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            DataContext = new CurrencyViewModel();
            ((CurrencyViewModel)DataContext).LoadCurrenciesAsync();
           
        }


        private void OnSearchTextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = SearchTextBox.Text.ToLower();
            var viewModel = (CurrencyViewModel)DataContext;
            if (viewModel != null && viewModel.Сurrencies != null)
            {
                var filteredList = viewModel.Сurrencies.Where(x => x.Name.ToLower().Contains(searchText)).ToList();
                MyListBox.ItemsSource = filteredList;
            }
        }
        //private void OnSearchTextBoxLostFocus(object sender, RoutedEventArgs e)  //<TextBox x:Name="SearchTextBox" TextChanged="OnSearchTextChanged" LostFocus="OnSearchTextBoxLostFocus"  />
        //{
        //    SearchTextBox.Text = "";
        //    MyListBox.ItemsSource = null;
        //}

        private void OnSelectionChanged(object sender, RoutedEventArgs e)
        {
            var selectedCurrency = (Currency)MyListBox.SelectedItem;
            if (selectedCurrency != null)
            {
                var currencyPage = new SelectedCurrency(selectedCurrency);
                //MainFrame.Navigate(currencyPage);
                NavigationService.Navigate(currencyPage);
            }
        }
    }
}
