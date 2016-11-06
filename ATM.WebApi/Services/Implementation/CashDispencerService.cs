using ATM.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM.Models;
using ATM.Helpers;

namespace ATM.Services.Implementation
{
    public class CashDispencerService : ICashDispencerService
    {
        public List<CurrencyNote> GetNoOfNotesAndDenomination(int amount)
        {
            var cdHelper = CashDispencingHelper.GetInstance();
            List<CurrencyNote> currencyNotes = null;
            cdHelper.GetNoOfNotesAndCount(ref amount, ref currencyNotes, 
                cdHelper.GetMaxCashDispencingHelper());

            return currencyNotes;
        }
    }
}
