using ATM.Models;
using ATM.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace ATM.Controllers
{
    public class CashDispencingController : ApiController
    {
        ICashDispencerService cashDispencerService;

        public CashDispencingController(ICashDispencerService _cashDispencerService)
        {
            if (_cashDispencerService == null)
                throw new ArgumentNullException(nameof(_cashDispencerService));
            cashDispencerService = _cashDispencerService;
        }

        [HttpGet]
        public IEnumerable<CurrencyNote> GetNoOfNotesAndDenomination(int amount)
        {
            return cashDispencerService.GetNoOfNotesAndDenomination(amount);
        }
    }
}
