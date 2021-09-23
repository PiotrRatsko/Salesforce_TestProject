using OpenQA.Selenium;
using Selenium_TestFrameWork;
using Selenium_TestFrameWork.CustomException;
using Selenium_TestFrameWork.WebDriverExtention;
using Tests.Entities;

namespace Tests.PageObject.Abstracts
{
    abstract class BasePage<T> where T : BasePage<T>
    {
        protected readonly IWebDriver driver;
        protected readonly LoginPage loginPage;

        #region IWebElements
        protected readonly By NewSObjectBtn = By.CssSelector("a[class='forceActionLink'][title='New']");
        protected readonly string sObjectNamePath = "(//a[@title='{0}'])[1]"; //find sObject by name
        #endregion IWebElements

        public BasePage(IWebDriver _driver)
        {
            LogHelper.log.Info("Initialized BasePage ctor: " + GetType().Name);
            driver = _driver;
            loginPage = new LoginPage(_driver);
        }

        //public abstract IEntity Entity { get; set; }
        public abstract NewSObjectPage NewSObjectPage { get; set; }
        public abstract SObjectPage SObjectPage { get; set; }
        public abstract By PageButton { get; set; }
        public abstract string PageUrl { get; set; }
        public abstract string PageTitle { get; set; }
        
        #region Actions
        private T CheckPageTilte()
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

        private T LoadPageByUrl()
        {
            driver.NavigateToUrl(PageUrl);
            return this as T;
        }

        private T LogInIfNeed(string userName = null, string password = null)
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

        public SObjectPage GetSObjectPage(string sObjectName)
        {
            ClickThisSObjectsPageBtn();
            driver.WaitForTitle(PageTitle);
            var formatedXPath = string.Format(sObjectNamePath, sObjectName);
            driver.ClickButton(By.XPath(formatedXPath));
            driver.WaitForTitle($"{sObjectName} | Salesforce");
            return (this as T).SObjectPage;
        }

        private T ClickThisSObjectsPageBtn()
        {
            driver.ClickButton(PageButton);
            driver.WaitForTitle(PageTitle);
            return this as T;
        }

        public T AddNewSObject(IEntity entity)
        {
            driver.WaitForTitle(PageTitle);
            driver.ClickButton(NewSObjectBtn);
            (this as T).NewSObjectPage.FillAndSaveNewSObject(entity);
            return ClickThisSObjectsPageBtn() as T;
        }
        #endregion Actions
    }
}
