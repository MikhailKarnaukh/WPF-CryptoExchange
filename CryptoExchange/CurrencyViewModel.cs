using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CryptoExchange
{
    public class CurrencyViewModel : INotifyPropertyChanged
    {
        private Currency _currencyToShow;
        private ObservableCollection<Currency> _currencies = new ObservableCollection<Currency>();


        public ObservableCollection<Currency> Сurrencies
        {
            get { return _currencies; }
            set { _currencies = value; }
        }



        public Currency CurrencyToShow
        {
            get { return _currencyToShow; }
            set
            {
                _currencyToShow = value;
                OnPropertyChanged("CurrencyToShow");
            }
        }
        public async Task LoadCurrencies()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://api.coingecko.com/api/v3/coins/list");
            string json = await response.Content.ReadAsStringAsync();
            List<Currency> currencies = JsonConvert.DeserializeObject<List<Currency>>(json);
            foreach (Currency currency in currencies)
            {
                if (currency != null)
                {
                    Сurrencies.Add(currency);
                }

            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string property = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
    }
}
