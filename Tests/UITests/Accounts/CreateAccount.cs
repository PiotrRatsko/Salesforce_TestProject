using NUnit.Framework;
using System;
using Tests.Entities;
using Tests.PageObject;
using Tests.Support;
using Tests.UITests;

namespace UITests.Accounts
{
    public class CreateAccount : BaseUITest
    {
        Account expectedAccount;
        string accountName;

        [SetUp]
        public void SetUp()
        {
            accountName = Guid.NewGuid().ToString();
            expectedAccount = new Account() { Name = accountName, Description = "Test Description", Type = "Customer - Direct" }
                .Validate<SetUIAttribute>() as Account;
        }

        [Test]
        [Category("UI")]
        [Retry(1)]
        public void CreateAccountTest()
        {
            AccountsPage ap = new AccountsPage(driver).GetPageDirectly().AddNewSObject(expectedAccount);

            Account actualAccount = ap.GetSObjectPage(accountName).GetDetails<Account>();

            expectedAccount.IsEqual<GetUIAttribute>(actualAccount);
        }
    }
}
