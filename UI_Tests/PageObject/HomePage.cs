using OpenQA.Selenium;
using Selenium_TestFrameWork;

namespace UI_Tests.PageObject
{
    public class HomePage : BasePage<HomePage>, IPageWithUrl
    {
        public HomePage(IWebDriver _driver) : base(_driver)
        {
            LogHelper.log.Info("initialized : " + this.GetType().Name);
        }

        #region IWebElements
        public string PageUrl { get; set; } = "";
        #endregion IWebElements

        #region Actions
        #endregion Actions 
    }
}
