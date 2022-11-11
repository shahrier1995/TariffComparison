using NUnit.Framework;
using System.Collections.Generic;
using TariffComparison;

namespace NUnitTest
{
    public class Tests
    {
        [Test]
        public void Test_Calculate_Annual_Cost_For_Product_A()
        {
            var testObj = new Tariff();
            double annualcost = testObj.ProductACalculation(1200);
            Assert.AreEqual(324, annualcost);
        }

        [Test]
        public void Test_Calculate_Annual_Cost_For_Product_B()
        {
            var testObj = new Tariff();
            double annualcost = testObj.ProductBCalculation(1200);
            Assert.AreEqual(800, annualcost);
        }

        [Test]
        public void Test_Get_Tariff_List_By_Ascending_Order()
        {
            var testObj = new Tariff();
            List<TariffModel> testList = new List<TariffModel>();
            testList.Add(new TariffModel { TariffName = "Basic electricity tariff", AnnualCost = 700 });
            testList.Add(new TariffModel { TariffName = "Package tariff", AnnualCost = 300 });
            testList = testObj.GetSortedList(testList);
            Assert.That(testList, Is.Ordered.By("AnnualCost"));
        }
    }
}