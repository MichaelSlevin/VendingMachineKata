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
        public void Display_InsertCoinMessage()
        {
            var display = new Display();
            Assert.AreEqual("INSERT COIN", display.InsertCoinMessage());
        }

        [TestMethod]
        public void Display_ThankYouMessage()
        {
            var display = new Display();
            Assert.AreEqual("THANK YOU", display.ThankYouMessage());
        }

        [DataTestMethod]
        [DataRow(100, "PRICE $1.00")]
        [DataRow(50, "PRICE $0.50")]
        [DataRow(65, "PRICE $0.65")]
        public void Display_InsufficientFunds(int priceOfItem, string expectedResult)
        {
            var display = new Display();
            Assert.AreEqual(expectedResult, display.InsufficientFunds(priceOfItem));
        }




    }
}
