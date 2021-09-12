using OpenQA.Selenium;
using Selenium_TestFrameWork;

namespace UI_Tests.PageObject
{
    class AccountsPage : BasePage<AccountsPage>
    {
        override public string PageUrl { get; set; } = "https://itechart-c.lightning.force.com/lightning/o/Account/list?filterName=Recent";
        public AccountsPage(IWebDriver _driver) : base(_driver)
        {
            LogHelper.log.Info("initialized : " + this.GetType().Name);
        }

        #region IWebElements
        //private readonly By Shadow_Root = By.CssSelector("hgf-globalnavigation");
        #endregion IWebElements

        #region Actions

        #endregion Actions 
    }
}
