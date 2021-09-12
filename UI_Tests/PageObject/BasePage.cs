using OpenQA.Selenium;
using Selenium_TestFrameWork;
using Selenium_TestFrameWork.WebDriverExtention;
using System;

namespace UI_Tests.PageObject
{
    public abstract class BasePage<T> : LoginPage<T>, IPageLoader<T>
    {
        public T LoadPageByUrl()
        {
            T obj = (T)Activator.CreateInstance(typeof(T), driver);
            driver.NavigateToUrl(this.PageUrl);
            return obj;
        }
        protected IWebDriver driver;
        public abstract string PageUrl { get; set; }
        public BasePage(IWebDriver _driver) : base(_driver)
        {
            LogHelper.log.Info("initialized : " + this.GetType().Name);
            driver = _driver;
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
