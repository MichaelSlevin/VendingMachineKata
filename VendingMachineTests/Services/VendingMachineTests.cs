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
            var _mockIVendingMachineOperations = new Mock<IVendingMachineOperations>();


            var expectedResult = "Mocked current message";
            _mockDisplay.Object.CurrentMessage = expectedResult;

            var vendingMachine = new VendingMachine(_mockMoneyHandler.Object, _mockProductHandler.Object, _mockDisplay.Object, _mockIVendingMachineOperations.Object);

            var returnedString = vendingMachine.CheckDisplay();
            Assert.AreEqual(expectedResult, returnedString);

        }

        [DataTestMethod]
        [DataRow("cola")]
        [DataRow("candy")]
        [DataRow("chips")]
        public void VendingMachine_PressButton_WithCorrectFunds_Calls_TryBuy_ThankYouMessage_CompleteSale_AndUpdateDisplay(string productName)
        {
            var _mockMoneyHandler = new Mock<MoneyHandler>();
            var _mockProductHandler = new Mock<ProductHandler>();
            var _mockDisplay = new Mock<Display>();
            var _mockIVendingMachineOperations = new Mock<IVendingMachineOperations>();

            _mockDisplay.Object.CurrentMessage = "mocked message";

            var vendingMachine = new VendingMachine(_mockMoneyHandler.Object, _mockProductHandler.Object, _mockDisplay.Object, _mockIVendingMachineOperations.Object);

            vendingMachine.PressButton(productName);

            _mockProductHandler.Verify(x => x.TryBuy(productName, 0));
            _mockDisplay.Verify(x => x.ThankYouMessage());
            _mockMoneyHandler.Verify(x => x.CompleteSale());
            _mockIVendingMachineOperations.Verify(x => x.UpdateDisplay("mocked message"));
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
            var _mockIVendingMachineOperations = new Mock<IVendingMachineOperations>();

            _mockProductHandler.Setup(x => x.TryBuy(productName, 0)).Throws<InsufficientCreditException>();

            var vendingMachine = new VendingMachine(_mockMoneyHandler.Object, _mockProductHandler.Object, _mockDisplay.Object, _mockIVendingMachineOperations.Object);

            vendingMachine.PressButton(productName);

            _mockProductHandler.Verify(x => x.TryBuy(productName, 0));
            _mockDisplay.Verify(x => x.InsufficientFunds(Constants.GetProductPrice(productName)));
            _mockMoneyHandler.Verify(x => x.CompleteSale(), Times.Never);
        }

        [TestMethod]
        public void VendingMaching_InsertCoin_CallsMoneyHandlerInsertCoinWithWeightAndDiamterProvided()
        {
            var _mockMoneyHandler = new Mock<MoneyHandler>();
            var _mockProductHandler = new Mock<ProductHandler>();
            var _mockDisplay = new Mock<Display>();
            var _mockIVendingMachineOperations = new Mock<IVendingMachineOperations>();

            var vendingMachine = new VendingMachine(_mockMoneyHandler.Object, _mockProductHandler.Object, _mockDisplay.Object, _mockIVendingMachineOperations.Object);

            vendingMachine.InsertCoin(Constants.WeightOfDime, Constants.DiameterOfDime);

            _mockMoneyHandler.Verify(x => x.InsertCoin(It.Is<Coin>(x=> x.Name = "Dime"));
        }

    }
}
