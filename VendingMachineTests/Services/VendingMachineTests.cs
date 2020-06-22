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
        public void vendingMachine_CheckDisplay_ReturnsTheCurrentDisplay()
        {
            var _mockMoneyHandler = new Mock<MoneyHandler>();
            var _mockProductHandler = new Mock<ProductHandler>();
            var _mockDisplay= new Mock<Display>();
           
            var vendingMachine = new VendingMachine(_mockMoneyHandler.Object,_mockProductHandler.Object, _mockDisplay.Object);

            vendingMachine.CheckDisplay();
            _mockDisplay.Verify(x => x.CurrentMessage);

        }

    }
}
