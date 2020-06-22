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
                    this.Cost = Constants.PriceOfCola;                   
                    break;
                case "candy":
                    this.Cost = Constants.PriceOfCandy;                   
                    break;
                case "chips":
                    this.Cost = Constants.PriceOfChips;                
                    break;
            }

        }

        public string Name { get; private set; }

        public int Cost { get; private set; }

    }
}
