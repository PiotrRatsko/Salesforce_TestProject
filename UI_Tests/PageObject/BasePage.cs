using OpenQA.Selenium;
using Selenium_TestFrameWork;
using Selenium_TestFrameWork.CustomException;
using Selenium_TestFrameWork.WebDriverExtention;

namespace Tests.PageObject
{
    abstract class BasePage<T> where T : BasePage<T>
    {
        protected readonly IWebDriver driver;
        private readonly LoginPage loginPage;

        #region IWebElements
        protected readonly By AccountsBtn = By.XPath("//a[@title='Accounts']/.."); //accounts button
        protected readonly By ContactsBtn = By.XPath("//a[@title='Contacts']/.."); //contacts button
        #endregion IWebElements

        public BasePage(IWebDriver _driver)
        {
            LogHelper.log.Info("Initialized BasePage ctor: " + GetType().Name);
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
                throw new PageTitleNotCorrect($"Page {GetType().Name} has wrong title: \"{driver.GetPageTitle()}\". Expected title: \"{PageTitle}\"");
            }
        }

        public T LoadPageByUrl()
        {
            driver.NavigateToUrl(PageUrl);
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

        public AccountsPage ClickAccountsBtn()
        {
            LogHelper.log.Info("Click accounts btn");
            driver.ClickButton(AccountsBtn);
            driver.WaitForTitle(PageTitle);
            return this as AccountsPage;
        }

        public ContactsPage ClickContactsBtn()
        {
            LogHelper.log.Info("Click contacts btn");
            driver.ClickButton(ContactsBtn);
            driver.WaitForTitle(PageTitle);
            return this as ContactsPage;
        }
        #endregion Actions
    }
}
