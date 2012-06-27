using Domain;

namespace Specs.Support
{
    public class DSL
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


        // Does ALL the work of withdrawing cash - automating that procress
        //public static void Whitdraw(Account account, int amountToWithdraw)
        //{
        //    var teller = new Teller(CashDispenser);
        //    teller.AuthenticateAs(account);
        //    teller.Withdraw(amountToWithdraw);
        //}

        public static void Whitdraw(Account account, int amountToWithdraw)
        {
            var atmAutomator = new AtmAutomator(CashDispenser);
            atmAutomator.AuthenticateAs(account);
            atmAutomator.Withdraw(amountToWithdraw);
        }

    }
}