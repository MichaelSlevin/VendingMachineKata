using System;
using VendingMachineKata.Model;

namespace VendingMachineKata.Model
{
    public class Product
    {
        public Product()
        {
        }

        public Product(string name)
        {
            this.Name = name;
            this.Price = Constants.GetProductPrice(name);                
        }

        public string Name { get; private set; }

        public int Price { get; private set; }

    }
}
