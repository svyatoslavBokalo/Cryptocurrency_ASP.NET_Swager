using CryptoCurrency.Models;

namespace CryptoCurrency.Repository
{
    public interface IRepository
    {
        bool Edit(int id, Cryptocurrency cryptocurrency);
        IList<Cryptocurrency> Read();

        bool DeleteId(int id);

        void WriteListInDB(IList<Cryptocurrency> cryptocurrencies);

        Cryptocurrency FindOne(int id);
        void DeleteAll();

        
    }
}
