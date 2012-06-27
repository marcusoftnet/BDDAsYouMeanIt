using Domain;

namespace Specs.Support
{
    public class DSL_Domain
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
        public static void Whitdraw(int amountToWithdraw)
        {
            var teller = new Teller(CashDispenser);
            teller.AuthenticateAs(MyAccount);
            teller.Withdraw(amountToWithdraw);
        }
    }
}