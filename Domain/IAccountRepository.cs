namespace Domain
{
    public interface IAccountRepository
    {
        Account GetAccount(int accountNo);
    }
}