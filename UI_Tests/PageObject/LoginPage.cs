using OpenQA.Selenium;
using Selenium_TestFrameWork;
using Selenium_TestFrameWork.Configuration;
using Selenium_TestFrameWork.WebDriverExtention;

namespace UI_Tests.PageObject
{
    class LoginPage
    {
        #region IWebElements
        private readonly By UserNameTxtBox = By.Id("username"); //userName Address textbox
        private readonly By PasswordTxtBox = By.Id("password"); //Password textbox
        private readonly By LogInBtn = By.Id("Login"); //Log In button
        #endregion IWebElements
        private readonly IWebDriver driver;

        public LoginPage(IWebDriver _driver)
        {
            LogHelper.log.Info("initialized : " + this.GetType().Name);
            driver = _driver;
        }

        #region Action
        public void LogIn(string userName = null, string password = null)
        {
            userName ??= Config.UserName;
            password ??= Config.Password;
            LogHelper.log.Info("Making LogIn:");
            driver.TypeInTextBox(UserNameTxtBox, userName);
            driver.TypeInTextBox(PasswordTxtBox, password);
            driver.ClickButton(LogInBtn);
        }
        #endregion Action
    }
}
