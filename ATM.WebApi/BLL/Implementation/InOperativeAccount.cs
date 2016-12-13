namespace ATM.WebApi.BLL.Implementation
{
    public class InOperativeAccount : Account
    {
        public override string AccountType => "In-Operative";

        private string AccountStatus { get; set; }

        public InOperativeAccount()
        {
            AccountStatus = "In-Operative";
        }

        public override bool Deposit()
        {
            AccountStatus = "Active";
            return base.Deposit();
        }

        public override bool WithDraw()
        {
            AccountStatus = "Active";
            return base.WithDraw();
        }

        public override string GetAccountStatus()
        {
            return AccountStatus;
        }
    }
}