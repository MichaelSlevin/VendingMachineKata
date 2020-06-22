using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendingMachineKata;
using Moq;

namespace VendingMachineTests
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


    }
}
