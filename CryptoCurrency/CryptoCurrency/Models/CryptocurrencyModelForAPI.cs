using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CryptoCurrency.Models
{
    //model to get a data from api
    public class CryptocurrencyModelForAPI : INotifyPropertyChanged
    {
        #region ctor
        private string _id;
        private string _rank;
        private string _symbol;
        private string _name;
        private string _supply;
        private string _maxSupply;
        private string _marketCapUsd;
        private string _volumeUsd24Hr;
        private string _priceUsd;
        private string _changePercent24Hr;
        private string _vwap24Hr;

        //to get data correctly
        public event PropertyChangedEventHandler? PropertyChanged;



        public string id
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    _id = value;
                    OnPropertyChanged(nameof(id));
                }
            }
        }

        public string rank
        {
            get { return _rank; }
            set
            {
                if (_rank != value)
                {
                    _rank = value;
                    OnPropertyChanged(nameof(rank));
                }
            }
        }

        public string symbol
        {
            get { return _symbol; }
            set
            {
                if (_symbol != value)
                {
                    _symbol = value;
                    OnPropertyChanged(nameof(symbol));
                }
            }
        }

        public string name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged(nameof(name));
                }
            }
        }

        public string supply
        {
            get { return _supply; }
            set
            {
                if (_supply != value)
                {
                    _supply = value;
                    OnPropertyChanged(nameof(supply));
                }
            }
        }

        public string maxSupply
        {
            get { return _maxSupply; }
            set
            {
                if (_maxSupply != value)
                {
                    _maxSupply = value;
                    OnPropertyChanged(nameof(maxSupply));
                }
            }
        }

        public string marketCapUsd
        {
            get { return _marketCapUsd; }
            set
            {
                if (_marketCapUsd != value)
                {
                    _marketCapUsd = value;
                    OnPropertyChanged(nameof(marketCapUsd));
                }
            }
        }

        public string volumeUsd24Hr
        {
            get { return _volumeUsd24Hr; }
            set
            {
                if (_volumeUsd24Hr != value)
                {
                    _volumeUsd24Hr = value;
                    OnPropertyChanged(nameof(volumeUsd24Hr));
                }
            }
        }

        public string priceUsd
        {
            get { return _priceUsd; }
            set
            {
                if (_priceUsd != value)
                {
                    _priceUsd = value;
                    OnPropertyChanged(nameof(priceUsd));
                }
            }
        }

        public string changePercent24Hr
        {
            get { return _changePercent24Hr; }
            set
            {
                if (_changePercent24Hr != value)
                {
                    _changePercent24Hr = value;
                    OnPropertyChanged(nameof(changePercent24Hr));
                }
            }
        }

        public string vwap24Hr
        {
            get { return _vwap24Hr; }
            set
            {
                if (_vwap24Hr != value)
                {
                    _vwap24Hr = value;
                    OnPropertyChanged(nameof(vwap24Hr));
                }
            }
        }

        public CryptocurrencyModelForAPI() { }
        public CryptocurrencyModelForAPI(string id, string rank, string symbol, string name, string supply, string maxSupply, string marketCapUsd, string volumeUsd24Hr, string priceUsd, string changePercent24Hr, string vwap24Hr)
        {
            this.id = id;
            this.rank = rank;
            this.symbol = symbol;
            this.name = name;
            this.supply = supply;
            this.maxSupply = maxSupply;
            this.marketCapUsd = marketCapUsd;
            this.volumeUsd24Hr = volumeUsd24Hr;
            this.priceUsd = priceUsd;
            this.changePercent24Hr = changePercent24Hr;
            this.vwap24Hr = vwap24Hr;
        }
        #endregion
        public override string ToString()
        {
            return $"Id: {id}\n" +
                           $"Rank: {rank}\n" +
                           $"Symbol: {symbol}\n" +
                           $"Name: {name}\n" +
                           $"Supply: {supply}\n" +
                           $"MaxSupply: {maxSupply}\n" +
                           $"MarketCapUsd: {marketCapUsd}\n" +
                           $"VolumeUsd24Hr: {volumeUsd24Hr}\n" +
                           $"PriceUsd: {priceUsd}\n" +
                           $"ChangePercent24Hr: {changePercent24Hr}\n" +
                           $"Vwap24Hr: {vwap24Hr}";
        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            // Ваш код для сповіщення про зміни значень властивостей
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
