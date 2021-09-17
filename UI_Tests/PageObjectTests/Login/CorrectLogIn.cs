using NUnit.Framework;
using Tests.PageObject;

namespace Tests.PageObjectTests.Login
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
