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

        [DataTestMethod]
        [DataRow("cola", 99)]
        [DataRow("chips", 49)]
        [DataRow("candy", 64)]
        public void ProductHandler_TryBuy_ThrowsIfInsufficientFunds(string productName, int currentCredit)
        {
            var productHandler = new ProductHandler();
            var exceptionMessage = "";
            try
            {
                productHandler.TryBuy(productName, currentCredit);
            }
            catch (InsufficientCreditException ex)
            {
                exceptionMessage = ex.Message;
            }

            Assert.AreEqual("Insufficient funds", exceptionMessage);
        }
    }
}
