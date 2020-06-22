using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendingMachineKata;
using Moq;

namespace VendingMachineTests
{
    [TestClass]
    public class MoneyHandlerTests
    {
        
        [TestMethod]
        public void MoneyHandler_InsertCoin_AddsCoinToTheStoredCoinsList()
        {
            var moneyHandler = new MoneyHandler();
            Assert.AreEqual(0, moneyHandler.StoredCoins.Count);

            var coin = new Coin(0, 0);

            moneyHandler.InsertCoin(coin);

            Assert.AreEqual(1, moneyHandler.StoredCoins.Count);
            Assert.IsTrue(moneyHandler.StoredCoins.Contains(coin));
        }  
        
        [TestMethod]
        public void MoneyHandler_IsCoinValid_ReturnsFalseIfNot()
        {
            var coin = new Coin(0,0);
            var moneyHandler = new MoneyHandler();

            var result = moneyHandler.IsCoinValid(coin);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void MoneyHandler_IsCoinValid_ReturnsTrueIfValid()
        {
            var dime = new Coin(Constants.WeightOfDime, Constants.DiameterOfDime);
            var nickel = new Coin(Constants.WeightOfNickel, Constants.DiameterOfNickel);
            var quarter = new Coin(Constants.WeightOfQuarter, Constants.DiameterOfQuarter);
            var moneyHandler = new MoneyHandler();

            var dimeResult = moneyHandler.IsCoinValid(dime);
            var nickelResult = moneyHandler.IsCoinValid(nickel);
            var quarterResult = moneyHandler.IsCoinValid(quarter);
            Assert.IsTrue(dimeResult);
            Assert.IsTrue(nickelResult);
            Assert.IsTrue(quarterResult);
        }

        //returns the correct coin
        [TestMethod]
        public void MoneyHandler_IdentifyCoin()
        {
            var moneyHandler = new MoneyHandler();

            var dimeResult = moneyHandler.IdentifyCoin(Constants.WeightOfDime, Constants.DiameterOfDime);
            var nickelResult = moneyHandler.IdentifyCoin(Constants.WeightOfNickel, Constants.DiameterOfNickel);
            var quarterResult = moneyHandler.IdentifyCoin(Constants.WeightOfQuarter, Constants.DiameterOfQuarter);
            var notAcceptedResult = moneyHandler.IdentifyCoin(Constants.WeightOfQuarter + 0.00001, Constants.DiameterOfQuarter);

            Assert.AreEqual("Dime", dimeResult.Name);
            Assert.AreEqual("Nickel", nickelResult.Name);
            Assert.AreEqual("Quarter", quarterResult.Name);
            Assert.AreEqual("Not accepted", notAcceptedResult.Name);

        }
    }
}
