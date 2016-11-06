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
        public List<CurrencyNote> GetNoOfNotesAndCount(int amount)
        {
            var cdHelper = CashDispencingHelper.GetInstance();
            List<CurrencyNote> currencyNotes = null;
            cdHelper.GetNoOfNotesAndCount(amount, currencyNotes, 
                cdHelper.GetMaxCashDispencingHelper());

            return currencyNotes;
        }
    }
}
