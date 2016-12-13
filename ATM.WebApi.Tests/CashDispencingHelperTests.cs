using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ATM.Helpers;
using ATM.WebApi.Helpers;

namespace ATM.WebApi.Tests
{
    [TestClass]
    public class CashDispencingHelperTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var helpr1 = CashDispencingHelper.GetInstance();
            var helpr2 = CashDispencingHelper.GetInstance();
            Assert.IsTrue(helpr1 == helpr2);
        }
    }
}
