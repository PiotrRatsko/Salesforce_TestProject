using NUnit.Framework;
using FluentAssertions;
using Tests.PageObject;
using Tests.Entities;

namespace Tests.PageObjectTests.Accounts
{
    public class CreateAccount : BaseTest
    {
        readonly Account account = new() { Name = "Test Account", Description = "Test Description", Type = "Customer - Direct" };

        [Test]
        [Retry(1)]
        public void CreateAccountTest()
        {
            account.Validate();

            AccountsPage ap = new AccountsPage(driver)
                .GetPageDirectly()
                .AddNewAccount(account);

            Account actualAccount = ap.GetAccount("Test Account");

            account.Should().BeEquivalentTo(actualAccount);
        }
    }
}
