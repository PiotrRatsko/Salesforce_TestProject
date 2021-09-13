using OpenQA.Selenium;
using Selenium_TestFrameWork;
using Selenium_TestFrameWork.WebDriverExtention;

namespace UI_Tests.PageObject
{
    abstract class BasePage<T> where T : BasePage<T>
    {
        #region IWebElements
        #endregion IWebElements

        private readonly IWebDriver driver;
        private readonly LoginPage loginPage;

        public BasePage(IWebDriver _driver)
        {
            LogHelper.log.Info("initialized BasePage ctor: " + this.GetType().Name);
            driver = _driver;
            loginPage = new LoginPage(_driver);
        }

        public abstract string PageUrl { get; set; }

        #region Actions
        public T LoadPageByUrl()
        {
            driver.NavigateToUrl(this.PageUrl);
            return this as T;
        }

        public T LogIn(string userName = null, string password = null)
        {
            loginPage.LogIn(userName, password);
            return this as T;
        }
        
        public AccountsPage ClickAccountsBtn()
        {
            //LogHelper.log.Info("ClickAccountsBtn: " + LoginBtn.ToString());
            return this as AccountsPage;
        }

        public ContactsPage ClickContactsBtn()
        {
            return this as ContactsPage;
        }
        #endregion Actions
    }
}
