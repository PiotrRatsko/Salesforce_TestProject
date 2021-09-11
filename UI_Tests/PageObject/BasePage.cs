using OpenQA.Selenium;
using Selenium_TestFrameWork;
using Selenium_TestFrameWork.WebDriverExtention;
using System;

namespace UI_Tests.PageObject
{
    public class BasePage<T> where T: IPageWithUrl
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
        public T LoadPage()
        {
            T obj = (T)Activator.CreateInstance(typeof(T), driver);
            driver.NavigateToUrl(obj.PageUrl);
            return obj;
        }

        public T LogIn()
        {
            T obj = (T)Activator.CreateInstance(typeof(T), driver);
            LoginPage lg = new LoginPage(driver).LogIn();
            return obj;
        }

        public AccountsPage ClickAccountsBtn()
        {
            //driver.GetShadowRoot(Shadow_Root).GetElement(LoginBtn).ClickButton();
            //LogHelper.log.Info("ClickButton: " + LoginBtn.ToString());
            return new AccountsPage(driver);
        }

        public ContactsPage ClickContactsBtn()
        {
            //driver.GetShadowRoot(Shadow_Root).GetElement(LoginBtn).ClickButton();
            //LogHelper.log.Info("ClickButton: " + LoginBtn.ToString());
            return new ContactsPage(driver);
        }
        #endregion Actions
    }
}
