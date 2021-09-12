using NUnit.Framework;
using Selenium_TestFrameWork;
using System.Threading;
using UI_Tests.PageObject;
using UI_Tests.PageObject.Tests;

namespace UI_Tests.PageObjectTests.Accounts
{
    public class CreateAccount : BaseTest
    {
        [Test]
        [Retry(2)]
        public void CreateAccountTest()
        {
            LogHelper.log.Info("Starting Test: " + TestContext.CurrentContext.Test.Name);
            ContactsPage ap = new AccountsPage(driver).LoadPageByUrl().LogIn().ClickContactsBtn();
            Thread.Sleep(10000);
        }
    }
}
