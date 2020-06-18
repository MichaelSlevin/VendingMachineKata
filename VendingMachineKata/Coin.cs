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
            else if (weight == Constants.WeightOfDime && diameter == Constants.DiameterOfDime)
            {
                Name = "Dime";
                Value = Constants.ValueOfDime;
                IsAccepted = true;
            }
            else if (weight == Constants.WeightOfQuarter && diameter == Constants.DiameterOfQuarter)
            {
                Name = "Quarter";
                Value = Constants.ValueOfQuarter;
                IsAccepted = true;
            }
            else
            {
                Name = "Not accepted";
                Value = 0;
                IsAccepted = false;
            }
        }

        public string Name { get; private set; }
        public int Value { get; private set; }
        public bool IsAccepted { get; private set; }
        
        
    }
}
