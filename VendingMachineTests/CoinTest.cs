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

        //Given non-recognised values, the coin constructor creates a coin object with value= 0 and name = not recognised
        [DataTestMethod]
        [DataRow(0,0)]
        [DataRow(5.1,23.4)]
        [DataRow(2,3)]
        [DataRow(100,72)]
        [DataRow(5.0000001, 21.21)]
        [DataRow(2.2679999999, 17.91)]
        [DataRow(5.6701, 24.26)]
        [DataRow(5,21.21)]
        [DataRow(2.2638,17.914)]
        [DataRow(5.6720,24.2611)]
        public void Coin_Constructor_GivenUnrecognisedWeightAndSizeCorrectlyAssignsPropertiesOfCoin(double weight, double diameter)
        {
            var coin = new Coin(weight, diameter);

            Assert.AreEqual("Not recognised", coin.Name);
            Assert.AreEqual(0, coin.Value);
            Assert.IsFalse(coin.IsAccepted);
        }
    }
}
