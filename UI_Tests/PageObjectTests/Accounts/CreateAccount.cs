using NUnit.Framework;
using FluentAssertions;
using UI_Tests.Entities;
using UI_Tests.PageObject;
using UI_Tests.PageObject.Tests;

namespace UI_Tests.PageObjectTests.Accounts
{
    public class CreateAccount : BaseTest
    {
        readonly Account account = new() { AccountName = "Test Account", Description = "Test Description", Type = "Customer" };

        [Test]
        [Retry(2)]
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
