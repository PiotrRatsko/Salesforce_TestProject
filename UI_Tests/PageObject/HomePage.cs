using OpenQA.Selenium;
using Selenium_TestFrameWork;

namespace UI_Tests.PageObject
{
    class HomePage : BasePage<HomePage>
    {
        override public string PageUrl { get; set; } = "https://itechart-c.lightning.force.com/lightning/page/home";
        public HomePage(IWebDriver _driver) : base(_driver)
        {
            LogHelper.log.Info("initialized : " + this.GetType().Name);
        }

        #region IWebElements
        #endregion IWebElements

        #region Actions
        #endregion Actions 
    }
}
