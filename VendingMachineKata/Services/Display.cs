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

        public void InsertCoinMessage()
        {
            CurrentMessage = "INSERT COIN";
        }

        public void ThankYouMessage()
        {
            CurrentMessage = "THANK YOU";
        }

        public void InsufficientFunds(int price)
        {
            var priceInDollars = String.Format("${0:0.00}", price/100d);
            CurrentMessage = $"PRICE {priceInDollars}";
        }
    }
}
