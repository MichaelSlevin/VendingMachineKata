using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendingMachineKata;
using Moq;

namespace VendingMachineTests
{
    [TestClass]
    public class ProductHandlerTests
    {       
        [DataTestMethod]
        [DataRow(100, "cola")]
        [DataRow(50, "chips")]
        [DataRow(65, "candy")]
        public void ProductHandler_GetProductPriceByName_RetursCorrectPrice(int expectedPrice, string productName)
        {
            var productHandler = new ProductHandler();

            var price = productHandler.GetProductPriceByName(productName);

            Assert.AreEqual(expectedPrice, price);
        }
    }
}
