using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestCustomer
{

    [TestClass]
    public class ResUnitTest
    {
        [TestMethod]
        public void PerforCalculation_Residential()
        {
            double expResAmount = 22;
            var ResTest = new CustomerDataLibrary.ClCustomer.ResidentialCustomer();
            ResTest.ResCustomer(22);
            double value = ResTest.rsum;
            Assert.AreEqual(expResAmount, value);
        }
    }


    [TestClass]
    public class ComUnitTest
    {
        [TestMethod]
        public void PerforCalculation_Commerical()
        {
            double expComAmount = 30;
            var ComTest = new CustomerDataLibrary.ClCustomer.CommercialCustomer();
            ComTest.ComCustomer(30);
            double value = ComTest.csum;
            Assert.AreEqual(expComAmount, value);
        }
      
    }
    [TestClass]
    public class IndUnitTest
    {
        [TestMethod]
        public void PerforCalculation_Industrial()
        {
            double expInsAmount = 50;
            var InsTest = new CustomerDataLibrary.ClCustomer.IndustrialCustomer();
            InsTest.IndCustomer(50);
            double value = InsTest.isum;
            Assert.AreEqual(expInsAmount, value);
        }
    }

    [TestClass]
    public class TotalAmountTest
    {
        [TestMethod]
        public void PerforCalculation_forTotalAmount()
        {
            double Amount = 270;
            var TestTotal = new CustomerDataLibrary.ClCustomer();
            double value = double.Parse(TestTotal.TotAmount(200,40,30));
            Assert.AreEqual(Amount, value);
        }
    }
    //CODE WRITTEN BY SHIJU ABRAHAM 27-09-24-
    [TestClass]
    public class TestCusCount
    {
        [TestMethod]
        public void CustomerCount()
        {
            int cnt  = 0;
            var TestCount = new CustomerDataLibrary.ClCustomer();
            int value = TestCount.customercount();
            Assert.AreEqual(cnt, value);
        }
    }

    [TestClass]
    public class TestCusType
    {
        [TestMethod]
        public void CustomerType()
        {
            string typeC = "Commerical";
            var TestType = new CustomerDataLibrary.CICustomerType();
            TestType.TypeCt(typeC);
            string value = TestType.CType;
            Assert.AreEqual(typeC, value);
        }
    }

}
