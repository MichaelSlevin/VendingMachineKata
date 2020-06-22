using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendingMachineKata;
using Moq;
using VendingMachineKata.Services;
using VendingMachineKata.Model;

namespace VendingMachineTests.Services
{
    [TestClass]
    public class MoneyHandlerTests
    {
        Coin dime1;
        Coin dime2;
        Coin nickel1;

        public MoneyHandlerTests()
        {
            dime1 = new Coin(Constants.WeightOfDime, Constants.DiameterOfDime);
            dime2 = new Coin(Constants.WeightOfDime, Constants.DiameterOfDime);
            nickel1 = new Coin(Constants.WeightOfNickel, Constants.DiameterOfNickel);
        }
        
        [TestMethod]
        public void MoneyHandler_InsertCoin_AddsCoinToTheStoredCoinsList()
        {
            var moneyHandler = new MoneyHandler();
            Assert.AreEqual(0, moneyHandler.InsertedCoins.Count);

            var coin = new Coin(Constants.WeightOfDime, Constants.DiameterOfDime);

            moneyHandler.InsertCoin(coin);

            Assert.AreEqual(1, moneyHandler.InsertedCoins.Count);
            Assert.IsTrue(moneyHandler.InsertedCoins.Contains(coin));
        }

        

        [TestMethod]
        public void MoneyHandler_InsertCoin_AddsCoinToReturnedCoinsWhenInvalid()
        {
            var moneyHandler = new MoneyHandler();
            Assert.AreEqual(0, moneyHandler.ReturnedCoins.Count);

            var coin = new Coin(0, 0);

            moneyHandler.InsertCoin(coin);

            Assert.AreEqual(0, moneyHandler.InsertedCoins.Count);        
            Assert.AreEqual(1, moneyHandler.ReturnedCoins.Count);        
        }

        [TestMethod]
        public void MoneyHandler_GetCurrentBalance_CorrectlyReturnsTheCurrentBalance()
        {


            var moneyHandler = new MoneyHandler();
            Assert.AreEqual(0, moneyHandler.GetCurrentBalance());
            moneyHandler.InsertedCoins.Add(dime1);
            moneyHandler.InsertedCoins.Add(dime2);
            moneyHandler.InsertedCoins.Add(nickel1);

            Assert.AreEqual(25, moneyHandler.GetCurrentBalance()) ;
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


        [TestMethod]
        public void MoneyHandler_CompleteSale_MovesInsertedCoinsToStoredCoinsList()
        {
            var moneyHandler = new MoneyHandler();
            moneyHandler.InsertedCoins.Add(dime1);
            moneyHandler.InsertedCoins.Add(nickel1);

            Assert.AreEqual(0, moneyHandler.StoredCoins.Count);
            Assert.AreEqual(2, moneyHandler.InsertedCoins.Count);
            moneyHandler.CompleteSale();

            Assert.AreEqual(2, moneyHandler.StoredCoins.Count);
            Assert.AreEqual(0, moneyHandler.InsertedCoins.Count);

            Assert.IsTrue(moneyHandler.StoredCoins.Contains(dime1));
            Assert.IsTrue(moneyHandler.StoredCoins.Contains(nickel1));
        }




    }
}
