using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ATM.WebApi.BLL.Implementation
{
    public class ActiveAccount : Account
    {
        public override string AccountType => "Active";

        public override string GetAccountStatus()
        {
            return "Active";
        }
    }
}