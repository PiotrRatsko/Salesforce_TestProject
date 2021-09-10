using OpenQA.Selenium;
using Selenium_TestFrameWork;
using Selenium_TestFrameWork.WebDriverExtention;

namespace UI_Tests.PageObject
{
    public class BasePage
    {
        protected IWebDriver driver;
        public BasePage(IWebDriver _driver)
        {
            LogHelper.log.Info("initialized : " + this.GetType().Name);
            driver = _driver;
        }

        #region IWebElements

        #endregion IWebElements

        #region Actions
        public AccountsPage GetAccountsPage()
        {
            //driver.GetShadowRoot(Shadow_Root).GetElement(LoginBtn).ClickButton();
            //LogHelper.log.Info("ClickButton: " + LoginBtn.ToString());
            return new AccountsPage(driver);
        }

        public ContactsPage GetContactsPage()
        {
            //driver.GetShadowRoot(Shadow_Root).GetElement(LoginBtn).ClickButton();
            //LogHelper.log.Info("ClickButton: " + LoginBtn.ToString());
            return new ContactsPage(driver);
        }
        #endregion Actions
    }
}
