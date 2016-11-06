using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ATM.Helpers;

namespace ATM.WebApi.Tests
{
    [TestClass]
    public class XmlHelperTests
    {
        [TestMethod]
        // Uncomment it if their is any change in CurrencyDenominations file in ATM.WebApi
        //[DeploymentItem("App_Data", "App_Data")]
        public void TestMethod1()
        {
            XmlHelper xmlHelper = new XmlHelper();
            var currencyDenominations = xmlHelper.CurrencyDenominations(@"CurrencyDenominations.xml");
            Assert.IsTrue(currencyDenominations != null);
            Assert.IsTrue(currencyDenominations.Count == 3);
        }

    }
}
