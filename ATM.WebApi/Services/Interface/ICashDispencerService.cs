using ATM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Services.Interface
{
    public interface ICashDispencerService
    {
        List<CurrencyNote> GetNoOfNotesAndDenomination(int amount);
    }
}
