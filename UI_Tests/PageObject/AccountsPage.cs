using OpenQA.Selenium;
using Selenium_TestFrameWork;
using Selenium_TestFrameWork.WebDriverExtention;

namespace UI_Tests.PageObject
{
    class AccountsPage : BasePage<AccountsPage>
    {
        #region IWebElements
        private readonly By NewAccountBtn = By.CssSelector("a[class='forceActionLink'][title='New']"); //new account button
        #endregion IWebElements

        public AccountsPage(IWebDriver _driver) : base(_driver)
        {
            LogHelper.log.Info("Initialized : " + this.GetType().Name);
        }

        override public string PageUrl { get; set; } = "https://itechart-c.lightning.force.com/lightning/o/Account/list?filterName=Recent";
        override public string PageTitle { get; set; } = "Recently Viewed | Accounts | Salesforce";

        #region Actions
        public NewAccountPage ClickNewAccountBtn()
        {
            driver.ClickButton(NewAccountBtn);
            return new NewAccountPage(driver);
        }
        #endregion Actions 
    }
}
