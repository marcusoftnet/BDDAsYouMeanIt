using Should.Fluent;
using TechTalk.SpecFlow;
using DSL = Specs.Support.DSL_Domain;
//using DSL = Specs.Support.DSL_Nancy;

namespace Specs.Steps
{
    [Binding]
    public class Steps
    {
        

        [Given(@"my account has a balance of \$(\d+)")]
        public void GivenInBalance(int balance)
        {
            DSL.MyAccount.Balance = balance;
        }

        [When(@"I withdraw \$(\d+)")]
        public void WithDrawAmount(int amountToWithdraw)
        {
            DSL.Whitdraw(amountToWithdraw);
        }   

        [Then(@"\$(\d+) should be dispensed")]
        public void AmountShouldBeDispensed(int expectedDispensedAmount)
        {
            DSL.CashDispenser.Contents.Should().Equal(expectedDispensedAmount);
        }

        [Then(@"the balance of my account should be \$(\d+)")]
        public void NewBalanceShouldBe(int expectedNewBalance)
        {
            DSL.MyAccount.Balance.Should().Equal(expectedNewBalance);
        }
    }


    
}
