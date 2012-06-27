using Domain;

namespace Specs.Support
{
    public class DSL_Nancy
    {
        private static Account _account;
        private static ICashDispenser _cashDispenser;
        public static Account MyAccount
        {
            get { return _account ?? (_account = new Account()); }
        }

        public static ICashDispenser CashDispenser
        {
            get { return _cashDispenser ?? (_cashDispenser = new FakeCashDispenser()); }
        }

        public static void Whitdraw(int amountToWithdraw)
        {
            var atmAutomator = new AtmAutomatorNancy(CashDispenser);
            atmAutomator.AuthenticateAs(MyAccount);
            atmAutomator.Withdraw(amountToWithdraw);
        }

    }
}