using OpenQA.Selenium;
using Selenium_TestFrameWork;
using Selenium_TestFrameWork.WebDriverExtention;

namespace UI_Tests.PageObject
{
    abstract class BasePage<T> where T : BasePage<T>
    {
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
        public AccountsPage ClickAccountsBtn()
        {
            //driver.GetShadowRoot(Shadow_Root).GetElement(LoginBtn).ClickButton();
            //LogHelper.log.Info("ClickButton: " + LoginBtn.ToString());
            return this as AccountsPage;
        }

        public ContactsPage ClickContactsBtn()
        {
            //driver.GetShadowRoot(Shadow_Root).GetElement(LoginBtn).ClickButton();
            //LogHelper.log.Info("ClickButton: " + LoginBtn.ToString());
            return this as ContactsPage;
        }
        #endregion Actions
    }
}
