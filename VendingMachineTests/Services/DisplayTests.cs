using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendingMachineKata;
using Moq;
using VendingMachineKata.Services;

namespace VendingMachineTests.Services
{
    [TestClass]
    public class DisplayTests
    {
        [TestMethod]
        public void Display_DefaultMessage_InsertCoinIf0Balance_ShowsBalanceIfBiggerThan0()
        {
            var display = new Display();
            display.DefaultMessage(0);
            Assert.AreEqual("INSERT COIN", display.CurrentMessage );

            display.DefaultMessage(10);
            Assert.AreEqual("$0.10", display.CurrentMessage);
        }

        [TestMethod]
        public void Display_ThankYouMessage()
        {
            var display = new Display();
            display.ThankYouMessage();
            Assert.AreEqual("THANK YOU", display.CurrentMessage);
        }

        [DataTestMethod]
        [DataRow(100, "PRICE $1.00")]
        [DataRow(50, "PRICE $0.50")]
        [DataRow(65, "PRICE $0.65")]
        public void Display_InsufficientFunds(int priceOfItem, string expectedResult)
        {
            var display = new Display();
            display.InsufficientFunds(priceOfItem);
            Assert.AreEqual(expectedResult, display.CurrentMessage);
        }

    }
}
