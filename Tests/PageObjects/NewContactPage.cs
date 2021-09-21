using OpenQA.Selenium;
using Selenium_TestFrameWork;
using Tests.PageObject.Abstracts;

namespace Tests.PageObject
{
    class NewContactPage : NewSObjectPage
    {
        #region IWebElements
        #endregion IWebElements

        public NewContactPage(IWebDriver _driver) : base(_driver)
        {
            LogHelper.log.Info("Initialized : " + GetType().Name);
        }

        public override string PageTitle { get; set; } = "New Contact | Salesforce";

        #region Actions
        #endregion Actions 
    }
}
