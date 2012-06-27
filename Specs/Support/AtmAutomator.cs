using Domain;
using Nancy.Testing;
using NSubstitute;
using Should.Fluent;
using Web;

namespace Specs.Support
{
    public class AtmAutomator
    {
        private readonly ICashDispenser _cashDispenser;
        private IAccountRepository _accountRepository;
        private Account _account;

        public AtmAutomator(ICashDispenser cashDispenser)
        {
            _cashDispenser = cashDispenser;
        }

        public void AuthenticateAs(Account account)
        {
            _account = account;
            _accountRepository = Substitute.For<IAccountRepository>();
            _accountRepository.GetAccount(account.AccountNo).Returns(account);
        }

        public void Withdraw(int amountToWithdraw)
        {
            var result = NancyBrowser.Post("/withdraw", with =>
            {
                with.HttpRequest();
                with.FormValue("accountNo", _account.AccountNo.ToString());
                with.FormValue("amount", amountToWithdraw.ToString());
            });

            result.Body.AsString().Should().Contain("It's done!");
        }

        private Browser NancyBrowser
        {
            get
            {
                var bootstrapper = new ConfigurableBootstrapper
                        (
                            with => with.Dependencies(_cashDispenser, _accountRepository)
                                        .Module<BankModule>()
                        );

                return new Browser(bootstrapper);
            }
        }
    }
}