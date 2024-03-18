using CryptoCurrency.Models;

namespace CryptoCurrency.Services.Interfaces
{
    public interface ICryptoCurrencyService
    {
        public Task GetFromAPI(string path);

        //public IList<T> Sorting<T>(IList<T> list);
    }
}
