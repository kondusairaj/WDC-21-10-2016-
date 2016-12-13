using System.Collections.Generic;
using ATM.Models;

namespace ATM.WebApi.Services.Interface
{
    public interface ICashDispencerService
    {
        List<CurrencyNote> GetNoOfNotesAndDenomination(int amount);
        List<string> GetAccountAndTransactionStatus(string operation, string accountType);
    }
}
