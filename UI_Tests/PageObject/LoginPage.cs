using OpenQA.Selenium;
using Selenium_TestFrameWork;
using Selenium_TestFrameWork.WebDriverExtention;

namespace UI_Tests.PageObject
{
    public class LoginPage
    {
        private readonly IWebDriver driver;

        public LoginPage(IWebDriver _driver)
        {
            driver = _driver;
            LogHelper.log.Info("initialized : " + this.GetType().Name);
        }

        #region IWebElements
        private readonly By UserNameTxtBox = By.Id("username"); //userName Address textbox
        private readonly By PasswordTxtBox = By.Id("password"); //Password textbox
        private readonly By LogInBtn = By.Id("Login"); //Log In button
        #endregion IWebElements

        #region Action
        public void LogIn(string userName, string password)
        {
            LogHelper.log.Info("Making LogIn:");
            driver.TypeInTextBox(UserNameTxtBox, userName);
            driver.TypeInTextBox(PasswordTxtBox, password);
            driver.ClickButton(LogInBtn);
        }
        #endregion Action
    }
}
