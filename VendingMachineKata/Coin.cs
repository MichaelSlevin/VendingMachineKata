using System;

namespace VendingMachineKata
{
    public class Coin
    {
        public Coin(double weight, double diameter)
        {
            if(weight == Constants.WeightOfNickel && diameter == Constants.DiameterOfNickel)
            {
                Name = "Nickel";
                Value = Constants.ValueOfNickel;
                IsAccepted = true;
            }
            if (weight == Constants.WeightOfDime && diameter == Constants.DiameterOfDime)
            {
                Name = "Dime";
                Value = Constants.ValueOfDime;
                IsAccepted = true;
            }
            if (weight == Constants.WeightOfQuarter && diameter == Constants.DiameterOfQuarter)
            {
                Name = "Quarter";
                Value = Constants.ValueOfQuarter;
                IsAccepted = true;
            }
        }

        public string Name { get; private set; }
        public int Value { get; private set; }
        public bool IsAccepted { get; private set; }
        
        
    }
}
