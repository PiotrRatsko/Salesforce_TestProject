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
            LogHelper.log.Info("initialized : " + this.GetType().Name);
            driver = _driver;
        }

        #region IWebElements
        private readonly By UserNameTxtBox = By.Id("username"); //userName Address textbox
        private readonly By PasswordTxtBox = By.Id("password"); //Password textbox
        private readonly By LogInBtn = By.Id("Login"); //Log In button
        #endregion IWebElements

        #region Action
        public BasePage LogInAndGetBasePage(string userName, string password)
        {
            LogHelper.log.Info("Making LogIn:");
            driver.TypeInTextBox(UserNameTxtBox, userName);
            driver.TypeInTextBox(PasswordTxtBox, password);
            driver.ClickButton(LogInBtn);
            return new BasePage(driver);
        }
        #endregion Action
    }
}
