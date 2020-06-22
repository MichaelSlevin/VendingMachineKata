using System;

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
                    this.Cost = 100;                   
                    break;
                case "candy":
                    this.Cost = 65;                   
                    break;
                case "chips":
                    this.Cost = 50;                   
                    break;
            }

        }

        public string Name { get; private set; }

        public int Cost { get; private set; }

    }
}
