using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendingMachineKata;
using Moq;
using VendingMachineKata.Model;
using VendingMachineKata.Services;

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
            var productHandler = new ProductHandler();

            var price = productHandler.GetProductPriceByName(productName);

            Assert.AreEqual(expectedPrice, price);
        }

        [DataTestMethod]
        [DataRow(100)]
        [DataRow(50)]
        [DataRow(65)]
        public void ProductHandler_TryBuy_ThrowsIfInsufficientFunds(int priceOfProduct)
        {
            var mockProduct = new Mock<Product>();
            mockProduct.Setup(x => x.Price).Returns(priceOfProduct);
            var insufficientCurrentCredit = priceOfProduct - 1;

            var productHandler = new ProductHandler();
            var exceptionMessage = "";
            try
            {
                productHandler.TryBuy(mockProduct.Object, insufficientCurrentCredit);
            }
            catch (InsufficientCreditException ex)
            {
                exceptionMessage = ex.Message;
            }

            Assert.AreEqual("Insufficient funds", exceptionMessage);
        }
    }
}
