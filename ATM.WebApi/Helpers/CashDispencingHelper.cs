using ATM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Helpers
{
    public class CashDispencingHelper
    {
        private static CashDispencingHelper _instance;

        private List<CurrencyDenomination> CurrencyDenominations { get; set; }

        protected CashDispencingHelper()
        {
            XmlHelper xmlHelper = new XmlHelper();
            CurrencyDenominations = xmlHelper.CurrencyDenominations("CurrencyDenominations.xml").OrderByDescending(x=>x.Value).ToList();
            AddSuccessorDenomination();
        }

        private void AddSuccessorDenomination()
        {
            for(int i=0; i< CurrencyDenominations.Count - 1; i++)
            {
                CurrencyDenominations[i].NextDenomination = CurrencyDenominations[i + 1];
            }
        }

        public static CashDispencingHelper GetInstance()
        {
            if(_instance == null)
            {
                _instance = new CashDispencingHelper();
            }
            return _instance;
        }

        public void GetNoOfNotesAndCount(ref int amount, ref List<CurrencyNote> notes, CurrencyDenomination denomination)
        {
            var cdhInstance = GetInstance();

            if (notes == null)
            {
                notes = new List<CurrencyNote>();
            }

            if (amount / denomination.Value > 0)
            {
                notes.Add(new CurrencyNote { Value = denomination.Value, Count = (amount / denomination.Value) });
                amount -= (denomination.Value * (amount / denomination.Value));
            }
            if (amount > 0 && denomination.NextDenomination != null)
            {
                GetNoOfNotesAndCount(ref amount, ref notes, denomination.NextDenomination);
            }
            if(amount > 0)
            {
                throw new Exception("Money Cannot be Dispenced");
            }
        }

        public CurrencyDenomination GetMaxCashDispencingHelper()
        {
            return CurrencyDenominations.FirstOrDefault();
        }
    }
}
