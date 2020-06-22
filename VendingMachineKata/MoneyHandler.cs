using System;
using System.Collections.Generic;

namespace VendingMachineKata
{
    public class MoneyHandler
    { 
        public List<Coin> StoredCoins { get; private set; }
        public List<Coin> ReturnedCoins { get; private set; }
        public int CurrentAmount { get; private set; }

        public MoneyHandler()
        {
            StoredCoins = new List<Coin>();
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
                StoredCoins.Add(coin);
                CurrentAmount += coin.Value;
            }
        }

        public bool IsCoinValid(Coin coin)
        {
            return coin.IsAccepted;
        }
    }
}
