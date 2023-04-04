using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CryptoExchange
{
    public class Currency : INotifyPropertyChanged
    {
        public string? _id;
        public string? _rank;
        public string? _symbol;
        public string? _name;
        public string? _supply;
        public string? _maxSupply;
        public string? _marketCapUsd;
        public string? _volumeUsd24Hr;
        public string? _priceUsd;
        public string? _changePercent24Hr;
        public string? _vwap24Hr;
        public string? _explorer;

        public string? Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged("Id");
            }
        }
        public string? Rank
        {
            get { return _rank; }
            set
            {
                _rank = value;
                OnPropertyChanged("Rank");
            }
        }
        public string? Symbol
        {
            get { return _symbol; }
            set
            {
                _symbol = value;
                OnPropertyChanged("Symbol");
            }
        }
        public string? Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }
        public string? Supply
        {
            get { return _supply; }
            set
            {
                _supply = value;
                OnPropertyChanged("Supply");
            }
        }
        public string? MaxSupply
        {
            get { return _maxSupply; }
            set
            {
                _maxSupply = value;
                OnPropertyChanged("MaxSupply");
            }
        }
        public string? MarketCapUsd
        {
            get { return _marketCapUsd; }
            set
            {
                _marketCapUsd = value;
                OnPropertyChanged("MarketCapUsd");
            }
        }
        public string? VolumeUsd24Hr
        {
            get { return _volumeUsd24Hr; }
            set
            {
                _volumeUsd24Hr = value;
                OnPropertyChanged("VolumeUsd24Hr");
            }
        }
        public string? PriceUsd
        {
            get { return _priceUsd; }
            set
            {
                _priceUsd = value;
                OnPropertyChanged("PriceUsd");
            }
        }
        public string? ChangePercent24Hr
        {
            get { return _changePercent24Hr; }
            set
            {
                _changePercent24Hr = value;
                OnPropertyChanged("ChangePercent24Hr");
            }
        }
        public string? VWap24hr
        {
            get { return _vwap24Hr; }
            set
            {
                _vwap24Hr = value;
                OnPropertyChanged("VWap24hr");
            }
        }
        public string? Explorer
        {
            get { return _explorer; }
            set
            {
                _explorer = value;
                OnPropertyChanged("Explorer");
            }
        }

        public Currency(string id, string rank, string symbol, string name,
                        string supply, string maxSupply, string marketCapUsd, string volumeUsd24Hr,
                        string priceUsd, string changePercent24Hr, string vwap24Hr, string explorer)
        {
            _id = id;
            _rank = rank;
            _symbol = symbol;
            _name = name;
            _supply = supply;
            _maxSupply = maxSupply;
            _marketCapUsd = marketCapUsd;
            _volumeUsd24Hr = volumeUsd24Hr;
            _priceUsd = priceUsd;
            _changePercent24Hr = changePercent24Hr;
            _vwap24Hr=vwap24Hr;
            _explorer = explorer;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string property = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
    }
}
