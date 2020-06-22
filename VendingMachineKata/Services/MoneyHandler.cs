using System;
using System.Collections.Generic;
using System.Linq;
using VendingMachineKata.Model;

namespace VendingMachineKata.Services
{
    public class MoneyHandler
    { 
        public List<Coin> StoredCoins { get; private set; }
        public List<Coin> InsertedCoins { get; private set; }
        public List<Coin> ReturnedCoins { get; private set; }

        public MoneyHandler()
        {
            StoredCoins = new List<Coin>();
            InsertedCoins = new List<Coin>();
            ReturnedCoins = new List<Coin>();
        }

        public Coin IdentifyCoin(double weight, double diameter)
        {
            return new Coin(weight, diameter);
        }

        public void InsertCoin(Coin coin)
        {
            if (!coin.IsAccepted)
            {
                ReturnedCoins.Add(coin);
            }
            else
            {
                InsertedCoins.Add(coin);
            }
        }

        public int GetCurrentBalance()
        {
            return InsertedCoins.Select(x => x.Value).Sum();
        }

        public bool IsCoinValid(Coin coin)
        {
            return coin.IsAccepted;
        }

        public virtual void CompleteSale()
        {
            StoredCoins.AddRange(InsertedCoins);
            InsertedCoins = new List<Coin>();
        }
    }
}
