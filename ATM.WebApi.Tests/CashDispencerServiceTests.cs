using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ATM.WebApi.BLL.Implementation;
using ATM.WebApi.BLL.Interface;
using ATM.WebApi.Services.Implementation;
using ATM.WebApi.Services.Interface;
using Microsoft.Practices.Unity;

namespace ATM.WebApi.Tests
{
    [TestClass]
    public class CashDispencerServiceTests
    {
        IUnityContainer _container;
        [TestInitialize]
        public void InitializeContainer()
        {
            var container = new UnityContainer();
            container.RegisterType<ICashDispencerService, CashDispencerService>(new HierarchicalLifetimeManager());
            container.RegisterType<IAccount, InOperativeAccount>("InOperativeAccount");
            container.RegisterType<IAccount, ActiveAccount>("ActiveAccount");
            container.RegisterType<IAccount, ClosedAccount>("ClosedAccount");
            container.RegisterType<IEnumerable<IAccount>, IAccount[]>();
            _container = container;
        }


        [TestMethod]
        public void MustFetchDenominations()
        {
            ICashDispencerService service = new CashDispencerService(_container);
            var a = service.GetNoOfNotesAndDenomination(3500);
            Assert.IsTrue(a != null);
            Assert.IsTrue(a.Count == 2);
            Assert.IsTrue(a[0].Value == 1000 && a[0].Count == 3);
            Assert.IsTrue(a[1].Value == 500 && a[1].Count == 1);
        }

        [TestMethod]
        public void MustFailToFetchDenominations()
        {
            try
            {
                ICashDispencerService service = new CashDispencerService(_container);
                var a = service.GetNoOfNotesAndDenomination(3550);
                Assert.Fail();
            }
            catch (Exception e)
            {
                Assert.IsTrue(e.Message == "Money Cannot be Dispenced");
            }
        }


        [TestMethod]
        public void MustFailWithAmountLessthanOne()
        {
            try
            {
                ICashDispencerService service = new CashDispencerService(_container);
                var a = service.GetNoOfNotesAndDenomination(-10);
                Assert.Fail();
            }
            catch (Exception e)
            {
                Assert.IsTrue(e.Message == "Amount cannot be less than or equal to zero.");
            }
        }

        [TestMethod]
        public void MustGetAccountAndTransactionStatus()
        {

            ICashDispencerService service = new CashDispencerService(_container);
            var result = service.GetAccountAndTransactionStatus("Deposit", "Active").ToList();
            Assert.IsTrue(result != null);
            Assert.IsTrue(Convert.ToBoolean(result[0]));
            Assert.IsTrue(result[1] == "Active");

            result = service.GetAccountAndTransactionStatus("Deposit", "Closed").ToList();
            Assert.IsTrue(result != null);
            Assert.IsTrue(!Convert.ToBoolean(result[0]));
            Assert.IsTrue(result[1] == "Closed");

            result = service.GetAccountAndTransactionStatus("Deposit", "In-Operative").ToList();
            Assert.IsTrue(result != null);
            Assert.IsTrue(Convert.ToBoolean(result[0]));
            Assert.IsTrue(result[1] == "Active");

        }
    }
}
