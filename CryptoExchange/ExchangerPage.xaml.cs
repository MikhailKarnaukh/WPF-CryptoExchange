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
    /// Логика взаимодействия для ExchangerPage.xaml
    /// </summary>
    public partial class ExchangerPage : Page
    {
        public ExchangerPage()
        {
            InitializeComponent();
            DataContext = new CurrencyViewModel();
            ((CurrencyViewModel)DataContext).LoadCurrenciesAsync();
        }
        private void SearchText(object sender, TextChangedEventArgs e)
        {
            string searchText = SearchTextBox.Text.ToLower();
            string searchText2 = SearchTextBox2.Text.ToLower();
            var viewModel = (CurrencyViewModel)DataContext;
            if (viewModel != null && viewModel.Currencies != null)
            {
                if (sender == SearchTextBox)
                {
                    var filteredList = viewModel.Currencies.Where(x => x.Name.ToLower().Contains(searchText)).ToList();
                    MyListBox.ItemsSource = filteredList;
                }
                else if (sender == SearchTextBox2)
                {
                    var filteredList = viewModel.Currencies.Where(x => x.Name.ToLower().Contains(searchText2)).ToList();
                    MyListBox2.ItemsSource = filteredList;
                }
            }
        }
        private void SelectFromListBox(object sender, RoutedEventArgs e)
        {
            var selectedCurrency = (Currency)MyListBox.SelectedItem;
            if (selectedCurrency != null)
            {
                SearchTextBox.Text = selectedCurrency.Name;
                double helper = Math.Round(Convert.ToDouble(selectedCurrency.PriceUsd.Replace(".", ",")), 4);
                Label.Content = helper.ToString() + " USD";
            }
        }
        private void SelectFromListBox2(object sender, RoutedEventArgs e)
        {
            var selectedCurrency = (Currency)MyListBox2.SelectedItem;
            if (selectedCurrency != null)
            {
                SearchTextBox2.Text = selectedCurrency.Name;
                double helper = Math.Round(Convert.ToDouble(selectedCurrency.PriceUsd.Replace(".",",")), 4 );
                Label2.Content = helper.ToString() + " USD";
            }
        }
        private void TextBoxLostFocus(object sender, RoutedEventArgs e)
        {
            var textBox = (TextBox)sender;
            if (textBox == SearchTextBox)
            {
                MyListBox.Visibility = Visibility.Collapsed;
            }
            else if (textBox == SearchTextBox2)
            {
                MyListBox2.Visibility = Visibility.Collapsed;
            }
        }

        private void CalculateResult(object sender, RoutedEventArgs e)
        {
            if (!(string.IsNullOrEmpty(SearchTextBox.Text) || (string.IsNullOrEmpty(SearchTextBox2.Text) || string.IsNullOrEmpty(InputQuantity.Text))))
            {
                var firstCurrency = (Currency)MyListBox.SelectedItem;
                var secondCurrency = (Currency)MyListBox2.SelectedItem;
                double firstCurrencyPrice = Math.Round(Convert.ToDouble(firstCurrency.PriceUsd.Replace(".", ",")), 4);
                double secondCurrencyPrice = Math.Round(Convert.ToDouble(secondCurrency.PriceUsd.Replace(".", ",")), 4);
                double quantity = Convert.ToDouble(InputQuantity.Text.Replace(".", ","));
                double result = Math.Round(firstCurrencyPrice * quantity / secondCurrencyPrice,4);
                Result.Content = result.ToString();
            }
        }
    }
}
