using OpenQA.Selenium;
using Selenium_TestFrameWork;
using Tests.Entities;
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
            Entity = new Account();
        }

        public override IEntity Entity { get; set; }
        #region Actions
        #endregion Actions 
    }
}