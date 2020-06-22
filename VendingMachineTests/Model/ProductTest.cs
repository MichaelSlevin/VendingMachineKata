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
        public void Product_Constructor_CreatesProductWithCorrectCostAndName(string productName, int cost)
        {
            var product = new Product(productName);
            Assert.AreEqual(cost, product.Cost);
            Assert.AreEqual(productName, product.Name);

        }
       
    }
}
