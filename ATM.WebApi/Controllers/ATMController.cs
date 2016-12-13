using System;
using System.Collections.Generic;
using System.Web.Http;
using ATM.Models;
using ATM.WebApi.Services.Interface;

namespace ATM.WebApi.Controllers
{
    // ReSharper disable once InconsistentNaming
    public class ATMController : ApiController
    {
        readonly ICashDispencerService _cashDispencerService;

        public ATMController(ICashDispencerService cashDispencerService)
        {
            if (cashDispencerService == null)
                throw new ArgumentNullException(nameof(cashDispencerService));
            _cashDispencerService = cashDispencerService;
        }

        [HttpGet]
        public IEnumerable<CurrencyNote> GetNoOfNotesAndDenomination(int amount)
        {
            return _cashDispencerService.GetNoOfNotesAndDenomination(amount);
        }

        [HttpGet]
        public IEnumerable<string> GetAccountAndTransactionStatus(string operation, string accountType)
        {
            return _cashDispencerService.GetAccountAndTransactionStatus(operation,accountType);
        }
    }
}
