using System;
using System.Collections.Generic;

namespace VendingMachineKata.Services
{
    public class Display
    {
        public string CurrentMessage;

        public Display()
        {
        }

        public virtual void InsertCoinMessage()
        {
            CurrentMessage = "INSERT COIN";
        }

        public virtual void ThankYouMessage()
        {
            CurrentMessage = "THANK YOU";
        }

        public virtual void InsufficientFunds(int price)
        {
            var priceInDollars = String.Format("${0:0.00}", price/100d);
            CurrentMessage = $"PRICE {priceInDollars}";
        }
    }
}
