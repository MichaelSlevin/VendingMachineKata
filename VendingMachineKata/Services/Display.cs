using System;
using System.Collections.Generic;

namespace VendingMachineKata.Services
{
    public class Display
    { 
        public Display()
        {
        }

        public string InsertCoinMessage()
        {
            return "INSERT COIN";
        }

        public string ThankYouMessage()
        {
            return "THANK YOU";
        }

        public string InsufficientFunds(int price)
        {
            var priceInDollars = String.Format("${0:0.00}", price/100d);
            return $"PRICE {priceInDollars}";
        }
    }
}
