using System;
using System.Collections.Generic;
using System.Linq;
using ATM.Models;
using ATM.WebApi.BLL.Interface;
using ATM.WebApi.Helpers;
using ATM.WebApi.Services.Interface;
using Microsoft.Practices.Unity;

namespace ATM.WebApi.Services.Implementation
{
    public class CashDispencerService : ICashDispencerService
    {
        public IUnityContainer Container { get; set; }
        public CashDispencerService(IUnityContainer container)
        {
            Container = container;
        }

        public List<CurrencyNote> GetNoOfNotesAndDenomination(int amount)
        {
            if (amount <= 0) throw new Exception("Amount cannot be less than or equal to zero.");
            var cdHelper = CashDispencingHelper.GetInstance();
            List<CurrencyNote> currencyNotes = null;
            cdHelper.GetNoOfNotesAndCount(ref amount, ref currencyNotes, 
                cdHelper.GetMaxCashDispencingHelper());

            return currencyNotes;
        }

        public List<string> GetAccountAndTransactionStatus(string operation, string accountType)
        {
            if (string.IsNullOrEmpty(operation)) throw new ArgumentNullException(nameof(operation));
            if (string.IsNullOrEmpty(accountType)) throw new ArgumentNullException(nameof(accountType));

            var a = Container.ResolveAll<IAccount>().ToList();
            var b = a.Find(x => string.Equals(x.AccountType, accountType, StringComparison.CurrentCultureIgnoreCase));

            if (b == null) return null;

            var result = new List<string>();
            switch (operation.ToUpper())
            {
                case "DEPOSIT":
                    result.Add(b.Deposit().ToString());
                    break;
                case "WITHDRAW":
                    result.Add(b.WithDraw().ToString());
                    break;
                case "BALANCE":
                    result.Add(b.GetBalance().ToString());
                    break;
            }
            result.Add(b.GetAccountStatus());
            return result;
        }
    }
}
