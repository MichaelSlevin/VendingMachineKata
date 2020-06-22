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
            switch (name) 
            {
                case "cola":
                    this.Price = Constants.PriceOfCola;                   
                    break;
                case "candy":
                    this.Price = Constants.PriceOfCandy;                   
                    break;
                case "chips":
                    this.Price = Constants.PriceOfChips;                
                    break;
            }

        }

        public string Name { get; private set; }

        public int Price { get; private set; }

    }
}
