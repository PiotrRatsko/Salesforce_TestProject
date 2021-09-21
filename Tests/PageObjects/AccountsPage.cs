using OpenQA.Selenium;
using Selenium_TestFrameWork;
using Tests.Entities;
using Tests.PageObject.Abstracts;

namespace Tests.PageObject
{
    class AccountsPage : BasePage<AccountsPage>
    {
        #region IWebElements
        public override By PageButton { get; set; } = By.XPath("//a[@title='Accounts']");
        #endregion IWebElements

        public AccountsPage(IWebDriver _driver) : base(_driver)
        {
            NewSObjectPage = new NewAccountPage(_driver);
            SObjectPage = new AccountPage(_driver);
            Entity = new Account();
            LogHelper.log.Info("Initialized : " + GetType().Name);
        }

        override public string PageUrl { get; set; } = "https://mycompany-63e-dev-ed.lightning.force.com/lightning/o/Account/list?filterName=Recent";
        override public string PageTitle { get; set; } = "Recently Viewed | Accounts | Salesforce";
        public override NewSObjectPage NewSObjectPage { get; set; }
        public override SObjectPage SObjectPage { get; set; }
        public override IEntity Entity { get; set; }

        #region Actions
        #endregion Actions 
    }
}