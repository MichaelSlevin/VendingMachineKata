using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendingMachineKata;
using Moq;
using VendingMachineKata.Services;
using VendingMachineKata.VendingMachineInterface;
using VendingMachineKata.Model;

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

        [DataTestMethod]
        [DataRow("cola")]
        [DataRow("candy")]
        [DataRow("chips")]
        public void VendingMachine_PressButton_WithCorrectFunds_Calls_TryBuyAndThankYouMessageAndCompleteSale(string productName)
        {
            var _mockMoneyHandler = new Mock<MoneyHandler>();
            var _mockProductHandler = new Mock<ProductHandler>();
            var _mockDisplay = new Mock<Display>();

            var vendingMachine = new VendingMachine(_mockMoneyHandler.Object, _mockProductHandler.Object, _mockDisplay.Object);

            vendingMachine.PressButton(productName);

            _mockProductHandler.Verify(x => x.TryBuy(productName, 0));
            _mockDisplay.Verify(x => x.ThankYouMessage());
            _mockMoneyHandler.Verify(x => x.CompleteSale());
        }

        [DataTestMethod]
        [DataRow("cola")]
        [DataRow("candy")]
        [DataRow("chips")]
        public void VendingMachine_PressButton_WithInCorrectFunds_Calls_TryBuyAndInsufficientFunds(string productName)
        {
            var _mockMoneyHandler = new Mock<MoneyHandler>();
            var _mockProductHandler = new Mock<ProductHandler>();
            var _mockDisplay = new Mock<Display>();

            _mockProductHandler.Setup(x => x.TryBuy(productName, 0)).Throws<InsufficientCreditException>();

            var vendingMachine = new VendingMachine(_mockMoneyHandler.Object, _mockProductHandler.Object, _mockDisplay.Object);

            vendingMachine.PressButton(productName);

            _mockProductHandler.Verify(x => x.TryBuy(productName, 0));
            _mockDisplay.Verify(x => x.InsufficientFunds(Constants.GetProductPrice(productName)));
            _mockMoneyHandler.Verify(x => x.CompleteSale(), Times.Never);
        }

    }
}
