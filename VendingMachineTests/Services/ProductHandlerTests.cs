using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendingMachineKata;
using Moq;
using VendingMachineKata.Model;
using VendingMachineKata.Services;
using System.Collections.Generic;

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

        [TestMethod]
        public void ProductHandler_TryBuy_ThrowsIfInsufficientFunds()
        {
            var productHandler = new ProductHandler();

            var cola = new Product("cola");
            var candy = new Product("candy");
            var chips = new Product("chips");

            var products = new List<Product>();

            products.Add(cola);
            products.Add(candy);
            products.Add(chips);

            var exceptionMessage = "";

            //try to buy each product with insufficient funds
            foreach (var product in products)
            {
                try
                {
                    productHandler.TryBuy(product, product.Price - 1);
                }
                catch (InsufficientCreditException ex)
                {
                    exceptionMessage = ex.Message;
                }

                Assert.AreEqual("Insufficient funds", exceptionMessage);
                exceptionMessage = "";
            }            
        }
    }
}
