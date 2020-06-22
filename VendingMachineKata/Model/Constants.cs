using System;

namespace VendingMachineKata.Model
{
    public static class Constants
    {
        public static int ValueOfNickel => 5;
        public static int ValueOfDime => 10;
        public static int ValueOfQuarter => 25;
        public static double WeightOfNickel => 5;
        public static double WeightOfDime => 2.268;
        public static double WeightOfQuarter => 5.670;
        public static double DiameterOfNickel => 21.21;
        public static double DiameterOfDime => 17.91;
        public static double DiameterOfQuarter => 24.26;
        public static int GetProductPrice(string productName)
        {
            switch (productName)
            {
                case "cola":
                    return 100;
                case "candy":
                    return 65;
                case "chips":
                    return 50;
                default:
                    return 0;                  
            }
        }



        
    }
}
