using OpenQA.Selenium;
using Selenium_TestFrameWork;

namespace UI_Tests.PageObject
{
    class HomePage : BasePage<HomePage>
    {
        #region IWebElements
        #endregion IWebElements

        public HomePage(IWebDriver _driver) : base(_driver) { LogHelper.log.Info("initialized : " + this.GetType().Name); }
        override public string PageUrl { get; set; } = "https://itechart-c.lightning.force.com/lightning/page/home";
        override public string PageTitle { get; set; } = "Home | Salesforce";

        #region Actions
        #endregion Actions 
    }
}
