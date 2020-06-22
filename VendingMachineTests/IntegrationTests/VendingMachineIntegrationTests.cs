using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendingMachineKata;
using Moq;
using VendingMachineKata.Services;
using VendingMachineKata.Model;
using VendingMachineKata.VendingMachineInterface;

namespace VendingMachineTests.IntegrationTests
{
    [TestClass]
    public class VendingMachineIntegrationTests
    {
        private readonly VendingMachine _vendingMachine;
        private readonly MoneyHandler _moneyHandler;
        private readonly Display _display;
        private readonly Mock<IVendingMachineOperations> _vendingMachineOperations;
        public VendingMachineIntegrationTests()
        {
            _vendingMachineOperations = new Mock<IVendingMachineOperations>();
            _moneyHandler = new MoneyHandler();
            _display = new Display();
            _vendingMachine = new VendingMachine(_moneyHandler, new ProductHandler(_vendingMachineOperations.Object), _display, _vendingMachineOperations.Object);
        }

        [DataTestMethod]
        [DataRow("candy")]
        [DataRow("cola")]
        [DataRow("chips")]
        public void PushButton_WithEnoughFunds_WorksCorrectly(string productName)
        {
            _vendingMachine.InsertCoin(Constants.WeightOfQuarter, Constants.DiameterOfQuarter);
            _vendingMachine.InsertCoin(Constants.WeightOfQuarter, Constants.DiameterOfQuarter);
            _vendingMachine.InsertCoin(Constants.WeightOfQuarter, Constants.DiameterOfQuarter);
            _vendingMachine.InsertCoin(Constants.WeightOfQuarter, Constants.DiameterOfQuarter);
            _vendingMachine.PressButton(productName);

            _vendingMachineOperations.Verify(x => x.DispenseProduct(It.Is<Product>(x => x.Name == productName)));
            _vendingMachineOperations.Verify(x => x.UpdateDisplay("THANK YOU"));

            Assert.AreEqual("INSERT COIN", _display.CurrentMessage);
            Assert.AreEqual(0, _moneyHandler.GetCurrentBalance());
        }

        //[DataTestMethod]
        //public void PushButton_WithInsufficientFunds_WorksCorrectly()
        //{

        //}

    }
}
