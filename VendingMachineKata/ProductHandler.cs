using System;
using System.Collections.Generic;

namespace VendingMachineKata
{
    public class ProductHandler
    {
        public ProductHandler()
        {
        }

        public int GetProductPriceByName(string name)
        {
            if (name == "cola")
                return 100;
            if (name == "chips")
                return 50;
            if (name == "candy")
                return 65;
            else
                return 0;
        }
    }
}

