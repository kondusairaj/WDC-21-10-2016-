using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ATM.Services.Implementation;
using ATM.Services.Interface;

namespace ATM.WebApi.Tests
{
    [TestClass]
    public class CashDispencerServiceTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            ICashDispencerService service = new CashDispencerService();
            var a = service.GetNoOfNotesAndDenomination(3500);
            Assert.IsTrue(a != null);
            Assert.IsTrue(a.Count == 2);
            Assert.IsTrue(a[0].Value == 1000 && a[0].Count == 3);
            Assert.IsTrue(a[1].Value == 500 && a[1].Count == 1);
        }

        [TestMethod]
        public void TestMethod2()
        {
            try
            {
                ICashDispencerService service = new CashDispencerService();
                var a = service.GetNoOfNotesAndDenomination(3550);
                Assert.Fail();
            }
            catch (Exception e)
            {
                Assert.IsTrue(true);
            }            
        }
    }
}
