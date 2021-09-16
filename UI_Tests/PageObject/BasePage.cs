using OpenQA.Selenium;
using Selenium_TestFrameWork;
using Selenium_TestFrameWork.CustomException;
using Selenium_TestFrameWork.WebDriverExtention;

namespace UI_Tests.PageObject
{
    abstract class BasePage<T> where T : BasePage<T>
    {
        #region IWebElements
        #endregion IWebElements

        protected readonly IWebDriver driver;
        private readonly LoginPage loginPage;

        public BasePage(IWebDriver _driver)
        {
            LogHelper.log.Info("Initialized BasePage ctor: " + this.GetType().Name);
            driver = _driver;
            loginPage = new LoginPage(_driver);
        }

        public abstract string PageUrl { get; set; }
        public abstract string PageTitle { get; set; }

        #region Actions
        public T CheckPageTilte()
        {
            try
            {
                driver.WaitForTitle(PageTitle);
                return this as T;
            }
            catch
            {
                throw new PageTitleNotCorrect($"Page {this.GetType().Name} has wrong title: \"{driver.GetPageTitle()}\". Expected title: \"{PageTitle}\"");
            }
        }

        public T LoadPageByUrl()
        {
            driver.NavigateToUrl(this.PageUrl);
            return this as T;
        }

        public T LogInIfNeed(string userName = null, string password = null)
        {
            if (driver.GetPageTitle() == loginPage.pageTitle)
            {
                loginPage.LogIn(userName, password);
            }
            return this as T;
        }

        public T GetPageDirectly()
        {
            LoadPageByUrl().LogInIfNeed().CheckPageTilte();
            return this as T;
        }

        //public AccountsPage ClickAccountsBtn()
        //{
        //    return this as AccountsPage;
        //}

        //public ContactsPage ClickContactsBtn()
        //{
        //    return this as ContactsPage;
        //}
        #endregion Actions
    }
}
