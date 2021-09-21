using OpenQA.Selenium;
using Selenium_TestFrameWork;
using Tests.PageObject.Abstracts;

namespace Tests.PageObject
{
    class NewAccountPage : NewSObjectPage
    {
        #region IWebElements
        #endregion IWebElements

        public NewAccountPage(IWebDriver _driver) : base(_driver)
        {
            LogHelper.log.Info("Initialized : " + GetType().Name);
        }

        public override string PageTitle { get; set; } = "New Account | Salesforce";

        #region Actions
        #endregion Actions 
    }
}
