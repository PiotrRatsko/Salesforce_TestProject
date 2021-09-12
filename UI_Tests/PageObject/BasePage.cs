using OpenQA.Selenium;
using Selenium_TestFrameWork;
using Selenium_TestFrameWork.WebDriverExtention;

namespace UI_Tests.PageObject
{
    public abstract class BasePage
    {
        public BasePage LoadPageByUrl()
        {
            driver.NavigateToUrl(this.PageUrl);
            return this;
        }

        public BasePage LogIn()
        {
            loginPage.LogIn();
            return this;
        }

        private readonly IWebDriver driver;
        private readonly LoginPage loginPage;
        public abstract string PageUrl { get; set; }
        public BasePage(IWebDriver _driver)
        {
            LogHelper.log.Info("initialized BasePage ctor: " + this.GetType().Name);
            driver = _driver;
            loginPage = new LoginPage(_driver);
        }

        #region IWebElements
        #endregion IWebElements

        #region Actions
        //public AccountsPage ClickAccountsBtn()
        //{
        //    //driver.GetShadowRoot(Shadow_Root).GetElement(LoginBtn).ClickButton();
        //    //LogHelper.log.Info("ClickButton: " + LoginBtn.ToString());
        //    return new AccountsPage(driver);
        //}

        //public ContactsPage ClickContactsBtn()
        //{
        //    //driver.GetShadowRoot(Shadow_Root).GetElement(LoginBtn).ClickButton();
        //    //LogHelper.log.Info("ClickButton: " + LoginBtn.ToString());
        //    return new ContactsPage(driver);
        //}
        #endregion Actions
    }
}
