using System;
using System.Collections.Generic;
using VendingMachineKata.Model;
using VendingMachineKata.VendingMachineInterface;

namespace VendingMachineKata.Services
{
    public class ProductHandler
    {
        private readonly IVendingMachineOperations _vendingMachineOperations;
        public ProductHandler(IVendingMachineOperations vendingMachineOperations)
        {
            _vendingMachineOperations = vendingMachineOperations;
        }

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

        public void TryBuy(Product product, int currentCredit)
        {
            if(currentCredit < product.Price)
            {
                throw new InsufficientCreditException("Insufficient funds");
            }
            else
            {
                _vendingMachineOperations.DispenseProduct(product);
            }
        }
    }
}

