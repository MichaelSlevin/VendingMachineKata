using System;
using System.Collections.Generic;
using VendingMachineKata.Model;

namespace VendingMachineKata.Services
{
    public class VendingMachine
    {
        private readonly MoneyHandler _moneyHandler;
        private readonly ProductHandler _productHandler;
        private readonly Display _display;

        public VendingMachine(MoneyHandler moneyHandler, ProductHandler productHandler, Display display)
        {
            _moneyHandler = moneyHandler;
            _productHandler = productHandler;
            _display = display;
        }

        public string CheckDisplay()
        {
            return _display.CurrentMessage;
        }

        public void PressButton(string productName)
        {
            var currentBalance = _moneyHandler.GetCurrentBalance();
            try
            {
                _productHandler.TryBuy(productName, currentBalance);
                _moneyHandler.CompleteSale();
                _display.ThankYouMessage();             
            }
            catch (InsufficientCreditException ex)
            {
                _display.InsufficientFunds(Constants.GetProductPrice(productName));
            }
            
        }
    }
}
