using NUnit.Framework;
using Selenium_TestFrameWork;
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
            HomePage sp = new StartPage(driver).LoadPageByUrl().ClickLoginBtnAndLogIn();
        }
    }
}
