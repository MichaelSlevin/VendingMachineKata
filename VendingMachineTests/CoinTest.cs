using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendingMachineKata;

namespace VendingMachineTests
{
    [TestClass]
    public class CoinTest
    {
        //Given the correct weight and diameter, the constructor produces the correct coin with the desired name, value and IsAccepted bool
        [TestMethod]
        public void Coin_Constructor_GivenWeightAndSizeCorrectlyAssignsPropertiesOfCoins()
        {
            var nickel = new Coin(Constants.WeightOfNickel, Constants.DiameterOfNickel);
            var dime = new Coin(Constants.WeightOfDime, Constants.DiameterOfDime);
            var quarter = new Coin(Constants.WeightOfQuarter, Constants.DiameterOfQuarter);

            Assert.AreEqual("Nickel", nickel.Name);
            Assert.AreEqual(Constants.ValueOfNickel, nickel.Value);
            Assert.IsTrue(nickel.IsAccepted);

            Assert.AreEqual("Dime", dime.Name);
            Assert.AreEqual(Constants.ValueOfDime, dime.Value);
            Assert.IsTrue(dime.IsAccepted);
            
            Assert.AreEqual("Quarter", quarter.Name);
            Assert.AreEqual(Constants.ValueOfQuarter, quarter.Value);
            Assert.IsTrue(quarter.IsAccepted);
        }
    }
}
