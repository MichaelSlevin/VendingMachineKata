using System;
using System.Collections.Generic;

namespace VendingMachineKata
{
    public class MoneyHandler
    { 
        public List<Coin> StoredCoins { get; private set; }

        public MoneyHandler()
        {
            StoredCoins = new List<Coin>();
        }

        public void InsertCoin(Coin coin)
        {
            StoredCoins.Add(coin);
        }

        public bool IsCoinValid(Coin coin)
        {
            return coin.IsAccepted;
        }
    }
}
