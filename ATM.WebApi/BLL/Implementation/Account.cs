using ATM.WebApi.BLL.Interface;

namespace ATM.WebApi.BLL.Implementation
{
    public abstract class Account : IAccount
    {
        public abstract string AccountType { get; }
        public abstract string GetAccountStatus();

        public virtual bool Deposit()
        {
            return true;
        }

        public virtual bool WithDraw()
        {
            return true;
        }
        
        public virtual bool GetBalance()
        {
            return true;
        }
    }
}