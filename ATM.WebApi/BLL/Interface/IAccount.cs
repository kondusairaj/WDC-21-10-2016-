namespace ATM.WebApi.BLL.Interface
{
    public interface IAccount
    {
        string AccountType { get;}
        bool Deposit();
        bool WithDraw();
        bool GetBalance();
        string GetAccountStatus();
    }
}
