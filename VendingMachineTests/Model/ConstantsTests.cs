using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendingMachineKata;
using VendingMachineKata.Model;

namespace VendingMachineTests.Model
{
    [TestClass]
    public class ConstantsTests
    {
        //test all the constant values are correct
        [TestMethod]
        public void Constants_CorrectValuesAssignedForWeightsSizesAndValues()
        {
            Assert.AreEqual(5, Constants.ValueOfNickel);
            Assert.AreEqual(10, Constants.ValueOfDime);
            Assert.AreEqual(25, Constants.ValueOfQuarter);

            Assert.AreEqual(5, Constants.WeightOfNickel);
            Assert.AreEqual(2.268, Constants.WeightOfDime);
            Assert.AreEqual(5.670, Constants.WeightOfQuarter);

            Assert.AreEqual(21.21, Constants.DiameterOfNickel);
            Assert.AreEqual(17.91, Constants.DiameterOfDime);
            Assert.AreEqual(24.26, Constants.DiameterOfQuarter);
        }

        [DataTestMethod]
        [DataRow("cola", 100)]
        [DataRow("candy", 65)]
        [DataRow("chips", 50)]
        public void Constants_GetProductPrice_CorrectValuesReturned(string nameOfProduct, int expectedPrice)
        {
            Assert.AreEqual(expectedPrice, Constants.GetProductPrice(nameOfProduct));

        }
    }
}
