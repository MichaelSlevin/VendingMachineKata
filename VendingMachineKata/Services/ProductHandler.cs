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
            return Constants.GetProductPrice(name);
        }

        public virtual void TryBuy(string productName, int currentCredit)
        {
            if (currentCredit < Constants.GetProductPrice(productName))
            {
                throw new InsufficientCreditException("Insufficient funds");
            }
            else
            {
                _vendingMachineOperations.DispenseProduct(new Product(productName));
            }
        }
    }
}

