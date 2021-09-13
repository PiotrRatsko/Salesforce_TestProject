using OpenQA.Selenium;
using Selenium_TestFrameWork;

namespace UI_Tests.PageObject
{
    class AccountsPage : BasePage<AccountsPage>
    {
        #region IWebElements
        #endregion IWebElements

        public AccountsPage(IWebDriver _driver) : base(_driver)
        {
            LogHelper.log.Info("initialized : " + this.GetType().Name);
        }

        override public string PageUrl { get; set; } = "https://itechart-c.lightning.force.com/lightning/o/Account/list?filterName=Recent";
        override public string PageTitle { get; set; } = "Recently Viewed | Accounts | Salesforce";

        #region Actions
        #endregion Actions 
    }
}
