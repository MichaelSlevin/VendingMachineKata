﻿using System;
using System.Collections.Generic;
using VendingMachineKata.Model;

namespace VendingMachineKata.Services
{
    public class ProductHandler
    {
        public ProductHandler()
        {
        }

        public int GetProductPriceByName(string name)
        {
            if (name == "cola")
                return Constants.PriceOfCola;
            if (name == "chips")
                return Constants.PriceOfChips;
            if (name == "candy")
                return Constants.PriceOfCandy;
            else
                return 0;
        }

        public void TryBuy(string productName, int currentCredit)
        {
            if(currentCredit < GetProductPriceByName(productName))
            {
                throw new InsufficientCreditException("Insufficient funds");
            }
        }
    }
}
