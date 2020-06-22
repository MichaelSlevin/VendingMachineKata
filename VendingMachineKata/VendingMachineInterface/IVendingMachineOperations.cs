using System;
using System.Collections.Generic;
using System.Text;
using VendingMachineKata.Model;

namespace VendingMachineKata.VendingMachineInterface
{
    //this interface remains unimplemented however it defines the contract that that objects responsible for
    //operating the vending machine should implement
    public interface IVendingMachineOperations
    {
        void DispenseProduct(Product product);
        void UpdateDisplay(string message);
    }
}
