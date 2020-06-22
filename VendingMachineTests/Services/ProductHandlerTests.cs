using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendingMachineKata;
using Moq;
using VendingMachineKata.Model;
using VendingMachineKata.Services;
using System.Collections.Generic;
using VendingMachineKata.VendingMachineInterface;

namespace VendingMachineTests.Services
{
    [TestClass]
    public class ProductHandlerTests
    {
        [DataTestMethod]
        [DataRow(100, "cola")]
        [DataRow(50, "chips")]
        [DataRow(65, "candy")]
        public void ProductHandler_GetProductPriceByName_ReturnsCorrectPrice(int expectedPrice, string productName)
        {
            var mockIVendingMachineOperations = new Mock<IVendingMachineOperations>();
            var productHandler = new ProductHandler(mockIVendingMachineOperations.Object);

            var price = productHandler.GetProductPriceByName(productName);

            Assert.AreEqual(expectedPrice, price);
        }

        [TestMethod]
        public void ProductHandler_TryBuy_ThrowsIfInsufficientFunds()
        {
            var mockIVendingMachineOperations = new Mock<IVendingMachineOperations>();
            var productHandler = new ProductHandler(mockIVendingMachineOperations.Object);

            var productNames = new List<string>();

            productNames.Add("cola");
            productNames.Add("candy");
            productNames.Add("chips");

            var exceptionMessage = "";

            //try to buy each product with insufficient funds
            foreach (var product in productNames)
            {
                try
                {
                    productHandler.TryBuy(product, Constants.GetProductPrice(product) - 1);
                }
                catch (InsufficientCreditException ex)
                {
                    exceptionMessage = ex.Message;
                }

                Assert.AreEqual("Insufficient funds", exceptionMessage);
                exceptionMessage = "";
            }
        }


        [DataTestMethod]
        [DataRow("cola", 0)]
        [DataRow("candy", 0)]
        [DataRow("chips", 0)]
        [DataRow("cola",1)]
        [DataRow("candy",29)]
        [DataRow("candy",200)]
        [DataRow("chips",321)]
        [DataRow("chips",743)]
        [DataRow("cola",2)]
        public void ProductHandler_TryBuy_CallsDispenseProductWithColaIfTheAvailableCreditIsSufficient(string nameOfProduct, int creditSurplus)
        {
            var mockIVendingMachineOperations = new Mock<IVendingMachineOperations>();
            var productHandler = new ProductHandler(mockIVendingMachineOperations.Object);

            var exceptionMessage = "";

            try
            {
                productHandler.TryBuy(nameOfProduct, Constants.GetProductPrice(nameOfProduct) + creditSurplus);
            }
            catch (InsufficientCreditException ex)
            {
                exceptionMessage = ex.Message;
            }

            //Check that an exception has not been thrown
            Assert.AreEqual("", exceptionMessage);
            //Check that the vending machine has been instructed to dispense the correct product
            mockIVendingMachineOperations.Verify(x => x.DispenseProduct(It.Is<Product>(x=> x.Name == nameOfProduct)));
        }
    }
}
