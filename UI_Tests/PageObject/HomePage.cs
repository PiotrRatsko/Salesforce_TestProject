using OpenQA.Selenium;
using Selenium_TestFrameWork;

namespace UI_Tests.PageObject
{
    public class HomePage : BasePage
    {
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
