using OpenQA.Selenium;
using Selenium_TestFrameWork;
using Tests.PageObject.Abstracts;

namespace Tests.PageObject
{
    class AccountPage : SObjectPage
    {
        #region IWebElements
        #endregion IWebElements

        public AccountPage(IWebDriver _driver) : base(_driver)
        {
            LogHelper.log.Info("Initialized : " + GetType().Name);
        }
        #region Actions
        #endregion Actions 
    }
}