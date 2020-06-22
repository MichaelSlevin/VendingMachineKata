using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendingMachineKata;
using Moq;
using VendingMachineKata.Services;
using VendingMachineKata.VendingMachineInterface;

namespace VendingMachineTests.IntegrationTests
{
    [TestClass]
    public class VendingMachineTests
    {
        [TestMethod]
        public void vendingMachine_CheckDisplay_ReturnsTheCurrentMessage()
        {
            var _mockMoneyHandler = new Mock<MoneyHandler>();
            var _mockProductHandler = new Mock<ProductHandler>();
            var _mockDisplay = new Mock<Display>();

            var expectedResult = "Mocked current message";
            _mockDisplay.Object.CurrentMessage = expectedResult;

            var vendingMachine = new VendingMachine(_mockMoneyHandler.Object, _mockProductHandler.Object, _mockDisplay.Object);

            var returnedString = vendingMachine.CheckDisplay();
            Assert.AreEqual(expectedResult, returnedString);

        }

    }
}