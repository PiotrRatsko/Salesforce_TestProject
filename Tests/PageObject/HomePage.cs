using OpenQA.Selenium;
using Selenium_TestFrameWork;

namespace Tests.PageObject
{
    class HomePage : BasePage<HomePage>
    {
        #region IWebElements
        #endregion IWebElements

        public HomePage(IWebDriver _driver) : base(_driver) { LogHelper.log.Info("initialized : " + GetType().Name); }
        override public string PageUrl { get; set; } = "https://mycompany-63e-dev-ed.lightning.force.com/lightning/page/home";
        override public string PageTitle { get; set; } = "Home | Salesforce";

        #region Actions
        #endregion Actions 
    }
}
