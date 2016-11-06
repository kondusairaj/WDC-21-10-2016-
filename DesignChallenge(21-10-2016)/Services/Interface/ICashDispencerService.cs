using ATM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Services.Interface
{
    interface ICashDispencerService
    {
        List<CurrencyNote> GetNoOfNotesAndCount(int amount);
    }
}
