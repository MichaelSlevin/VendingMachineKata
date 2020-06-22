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

        public Coin IdentifyCoin(double weight, double diameter)
        {
            return new Coin(weight, diameter);
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
