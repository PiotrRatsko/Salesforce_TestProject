using OpenQA.Selenium;
using Selenium_TestFrameWork;
using Tests.Entities;
using Tests.PageObject.Abstracts;

namespace Tests.PageObject
{
    class ContactPage : SObjectPage
    {
        #region IWebElements
        #endregion IWebElements

        public ContactPage(IWebDriver _driver) : base(_driver)
        {
            LogHelper.log.Info("Initialized : " + GetType().Name);
            Entity = new Contact();
        }

        public override IEntity Entity { get; set; }
        #region Actions
        #endregion Actions 
    }
}