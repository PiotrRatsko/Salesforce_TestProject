using NUnit.Framework;
using FluentAssertions;
using Tests.PageObject;
using Tests.Entities;
using Tests.PageObjectTests;

namespace PageObjectTests.Accounts
{
    public class CreateAccount : BaseUITest
    {
        readonly Account expectedAccount = new() { Name = "Test Account", Description = "Test Description", Type = "Customer - Direct" };

        [Test]
        [Category("UI")]
        [Retry(2)]
        public void CreateAccountTest()
        {
            expectedAccount.Validate();

            AccountsPage ap = new AccountsPage(driver)
                .GetPageDirectly()
                .AddNewAccount(expectedAccount);

            Account actualAccount = ap.GetAccount("Test Account");

            expectedAccount.Should().BeEquivalentTo(actualAccount);
        }
    }
}
