using OpenQA.Selenium;
using Selenium_TestFrameWork;
using Selenium_TestFrameWork.Configuration;
using Selenium_TestFrameWork.WebDriverExtention;

namespace Tests.PageObject
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
            LogHelper.log.Info("Initialized : " + GetType().Name);
            driver = _driver;
        }

        public readonly string pageTitle = "Login | Salesforce";

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
