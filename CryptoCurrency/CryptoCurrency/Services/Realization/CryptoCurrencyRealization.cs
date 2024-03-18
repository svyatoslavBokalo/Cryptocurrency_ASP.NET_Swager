using CryptoCurrency.ApiActions;
using CryptoCurrency.Models;
using CryptoCurrency.Repository;
using CryptoCurrency.Services.Interfaces;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;

namespace CryptoCurrency.Services.Realization
{
    public class CryptoCurrencyRealization : ICryptoCurrencyService
    {
        IRepository repository;
        public CryptoCurrencyRealization(IRepository repository)
        {
            this.repository = repository;
        }

        //when we use this models 
        public async Task GetFromAPI(string path)
        {
            IList<CryptocurrencyModelForAPI> collection = await ActionsOfData.GetDataFromCoinCap<CryptocurrencyModelForAPI>(path);
            IList<Cryptocurrency> result = ALLDataParse(collection);
            repository.WriteListInDB(result);

        }

        //this method parse collection to our model
        private IList<Cryptocurrency> ALLDataParse(IList<CryptocurrencyModelForAPI> data)
        {
            IList<Cryptocurrency> res = new List<Cryptocurrency>();
            foreach (CryptocurrencyModelForAPI model in data)
            {
                res.Add(ParseForDB(model));
            }
            return res;
        }
        //this method parse string to double or if it's null it will ne null
        private Cryptocurrency ParseForDB(CryptocurrencyModelForAPI crypto)
        {
            double res;
            Cryptocurrency result = new Cryptocurrency()
            {
                id_text = crypto.id,
                Rank = crypto.rank,
                Symbol = crypto.symbol,
                Name = crypto.name,
                Supply = double.TryParse(CheckNull(crypto.supply), out res) ? res : null,
                MaxSupply = double.TryParse(CheckNull(crypto.maxSupply), out res) ? res : null,
                MarketCapUsd = double.TryParse(CheckNull(crypto.marketCapUsd), out res) ? res : null,
                VolumeUsd24Hr = double.TryParse(CheckNull(crypto.volumeUsd24Hr), out res) ? res : null,
                PriceUsd = double.TryParse(CheckNull(crypto.priceUsd), out res) ? res : null,
                ChangePercent24Hr = double.TryParse(CheckNull(crypto.changePercent24Hr), out res) ? res : null,
                Vwap24Hr = double.TryParse(CheckNull(crypto.vwap24Hr), out res) ? res : null,
                action = 1
            };
            return result;
        }

        //this method check null
        private string? CheckNull(string line)
        {
            return line is null ? null : line.Replace('.', ',');
        }

        //public IList<T> Sorting<T>(IList<T> lst, string nameOfProperty = "id")
        //{
        //    PropertyInfo[] properties = typeof(T).GetProperties();

        //    PropertyInfo sortingProperty = properties.FirstOrDefault(p => p.Name.ToLower() == nameOfProperty.ToLower());

        //    IList<T> sortedList = new ObservableCollection<T>(
        //        lst.OrderBy(item => sortingProperty.GetValue(item)));
        //    return sortedList;
        //}
    }
}
