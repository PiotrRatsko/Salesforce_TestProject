using NUnit.Framework;
using Selenium_TestFrameWork;
using System.Threading;
using UI_Tests.PageObject;
using UI_Tests.PageObject.Tests;

namespace UI_Tests.PageObjectTests.Login
{
    public class CorrectLogIn : BaseTest
    {
        [Test]
        [Retry(2)]
        public void CorrectLogInTest()
        {
            LogHelper.log.Info("Starting Test: " + TestContext.CurrentContext.Test.Name);
            HomePage sp = new StartPage(driver).LoadPageByUrl().LogIn();

            Thread.Sleep(10000);
        }
    }
}
