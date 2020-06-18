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

            var mockCoin = new Mock<Coin>();

            moneyHandler.InsertCoin(mockCoin.Object);

            Assert.AreEqual(0, moneyHandler.StoredCoins.Count);
            Assert.IsTrue(moneyHandler.StoredCoins.Contains(mockCoin.Object));



        }

      
    }
}
