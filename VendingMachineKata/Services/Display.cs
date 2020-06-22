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

        public virtual void DefaultMessage(int currentBalance)
        {
            if (currentBalance == 0)
            {
                CurrentMessage = "INSERT COIN";
            }
            else
            {
                CurrentMessage = GetPriceInDollars(currentBalance);
            }
        }

        public virtual void ThankYouMessage()
        {
            CurrentMessage = "THANK YOU";
        }

        public virtual void InsufficientFunds(int price)
        {
            
            CurrentMessage = $"PRICE {GetPriceInDollars(price)}";
        }

        private string GetPriceInDollars(int cent)
        {
            return String.Format("${0:0.00}", cent / 100d);
        }
    }
}
