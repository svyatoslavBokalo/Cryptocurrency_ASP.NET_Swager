using CryptoCurrency.DBContext;
using CryptoCurrency.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CryptoCurrency.Repository
{
    public class RepositoryRealization : IRepository
    {
        private readonly DbContextApplication context;

        public RepositoryRealization(DbContextApplication context)
        {
            this.context = context;
        }


        //in this method use other table "DeletedCryptocurency"
        // when we delete crypto we update action=0 and  do not show this cryptocurrency to users
        public bool DeleteId(int id)
        {
            Cryptocurrency existingItem = context.Cryptocurrencies.First(el => el.Id == id);

            if (existingItem == null)
            {
                return false;
            }

            existingItem.action = 0;
            context.DeletedCryptocurrencies.Add(new DeletedCryptocurrency() { IdCrypto =  id });
            context.SaveChanges();
            return true;
        }

        // delete all data
        // and it's for me just clean data base
        public void DeleteAll()
        {
            
            var allRecords = context.Cryptocurrencies.ToList();
            context.Cryptocurrencies.RemoveRange(allRecords);
            context.SaveChanges();

        }


        // change data
        public bool Edit(int id, Cryptocurrency cryptocurrency)
        {
            Cryptocurrency existingItem = context.Cryptocurrencies.First(el => el.Id == id);

            if (existingItem == null)
            {
                return false;
            }

            existingItem.Id = id;
            existingItem.id_text = cryptocurrency.id_text;
            existingItem.Rank = cryptocurrency.Rank;
            existingItem.Symbol = cryptocurrency.Symbol;
            existingItem.Name = cryptocurrency.Name;
            existingItem.Name = cryptocurrency.Name;
            existingItem.Supply = cryptocurrency.Supply;
            existingItem.MaxSupply = cryptocurrency.MaxSupply;
            existingItem.MarketCapUsd = cryptocurrency.MarketCapUsd;
            existingItem.VolumeUsd24Hr = cryptocurrency.VolumeUsd24Hr;
            existingItem.PriceUsd = cryptocurrency.PriceUsd;
            existingItem.ChangePercent24Hr = cryptocurrency.ChangePercent24Hr;
            existingItem.Vwap24Hr = cryptocurrency.Vwap24Hr;


            context.SaveChanges();
            return true;

        }

        public Cryptocurrency FindOne(int id)
        {

            return context.Cryptocurrencies.First(el => el.Id == id);
        }

        public IList<Cryptocurrency> Read()
        {
            IList<Cryptocurrency> res = new List<Cryptocurrency>();
            res = CheckAction(context.Cryptocurrencies.ToList());
            return res;
        }

        //this method is check if action!=0
        //if yes then we show this crypto to ussers
        private IList<Cryptocurrency> CheckAction(IList<Cryptocurrency> data)
        {
            IList<Cryptocurrency> res = new List<Cryptocurrency>();
            foreach (var item in data)
            {
                if (item.action != 0 && item.action!=null)
                {
                    res.Add(item);
                }
            }
            return res;
        }

        public void WriteListInDB(IList<Cryptocurrency> cryptocurrencies)
        {
            context.Cryptocurrencies.AddRange(cryptocurrencies);
            context.SaveChanges();
        }
    }
}
