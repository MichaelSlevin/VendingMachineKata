using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendingMachineKata;
using VendingMachineKata.Model;

namespace VendingMachineTests.Model
{
    [TestClass]
    public class ProductTest
    {
        [DataTestMethod]
        [DataRow("cola", 100)]
        [DataRow("candy", 65)]
        [DataRow("chips", 50)]
        public void Product_Constructor_CreatesProductWithCorrectPriceAndName(string productName, int price)
        {
            var product = new Product(productName);
            Assert.AreEqual(price, product.Price);
            Assert.AreEqual(productName, product.Name);

        }
       
    }
}
