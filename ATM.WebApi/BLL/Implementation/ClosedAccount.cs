namespace ATM.WebApi.BLL.Implementation
{
    public class ClosedAccount : Account
    {
        public override string AccountType => "Closed";

        public override bool GetBalance()
        {
            return false;
        }

        public override bool Deposit()
        {
            return false;
        }

        public override bool WithDraw()
        {
            return false;
        }

        public override string GetAccountStatus()
        {
            return "Closed";
        }
    }
}