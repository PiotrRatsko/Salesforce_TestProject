using NUnit.Framework;
using System.Threading;
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
            AccountsPage ap = new AccountsPage(driver).GetPageDirectly();
            account.Validate();
            NewAccountPage nap = ap.ClickNewAccountBtn();
            nap.FillAndSaveNewAccount(account);
            Thread.Sleep(5000);
        }
    }
}
