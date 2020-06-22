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
        private readonly VendingMachine _vendingMachine;
        private readonly Mock<IVendingMachineOperations> _vendingMachineOperations;
        public VendingMachineTests()
        {
            _vendingMachineOperations = new Mock<IVendingMachineOperations>();
            _vendingMachine = new VendingMachine(new MoneyHandler(), new ProductHandler(_vendingMachineOperations.Object));
        }

        [TestMethod]
        public void VendingMachine_PressTheColaButtonWithCorrectFunds()
        {
            
        }

    }
}
