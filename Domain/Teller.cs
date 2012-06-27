namespace Domain
{
    public class Teller
    {
        private Account _account;
        private ICashDispenser _cashDispsener;

        public Teller(ICashDispenser CashDispenser)
        {
            _cashDispsener = CashDispenser;
        }

        public void AuthenticateAs(Account account)
        {
            _account = account;
        }

        public void Withdraw(int amount)
        {
            _account.Balance -= amount;
            _cashDispsener.Dispense(amount);

        }
    }
}