using System;
using Domain;
using Nancy;
using Nancy.ModelBinding;

namespace Web
{

    public class BankModule : NancyModule
    {
        private readonly ICashDispenser _dispenser;
        private readonly IAccountRepository _accountRepo;

        public BankModule(ICashDispenser dispenser, IAccountRepository accountRepo)
        {
            _dispenser = dispenser;
            _accountRepo = accountRepo;

            Get["/"] = _ =>
                           {
                               return @"<html>
                                          <body>
                                            <form action='/withdraw' method='post'>
                                              <label for='accountNo'>Account no</label>
                                              <input type='text' name='accountNo' id='accountNo'>
                                              <br />
                                              <label for='amount'>Amount</label>
                                              <input type='text' name='amount' id='amount'>
                                              <br />
                                              <input type='submit' name='withdraw' id='withdraw' value='Withdraw'>
                                            </form>
                                          </body>
                                        </html>";
                           };

            Post["/withdraw"] = p =>
                                    {
                                        var vm = this.Bind<WithdrawalVM>();
                                        var account = _accountRepo.GetAccount(vm.AccountNo);
                                        var teller = new Teller(_dispenser);
                                        teller.AuthenticateAs(account);
                                        teller.Withdraw(vm.Amount);
                                        return "It's done!";
                                    };
        }

    }

    public class WithdrawalVM
    {
        public int Amount { get; set; }
        public int AccountNo { get; set; }
    }
}