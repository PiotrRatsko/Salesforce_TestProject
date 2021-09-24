using NUnit.Framework;
using System;
using Tests.Entities;
using Tests.PageObject;
using Tests.Support;
using Tests.Support.CustomAttributes;

namespace Tests.UITests.Accounts
{
    public class CreateAccount : BaseUITest
    {
        readonly Account account = new Account()
        {
            Name = Guid.NewGuid().ToString(),
            Description = "Test Description",
            Type = "Customer - Direct"
        }.Validate() as Account;

        [Test]
        [Category("UI")]
        [Retry(1)]
        public void CreateAccountTest()
        {
            AccountsPage ap = new AccountsPage(driver).GetPageDirectly().AddNewSObject(account);
            var expectedAccount = account.TransformTo<GetFieldsUI>();
            var actualAccount = ap.GetSObjectPage(account.Name).GetDetails();
            actualAccount.IsContains(expectedAccount);
        }
    }
}
