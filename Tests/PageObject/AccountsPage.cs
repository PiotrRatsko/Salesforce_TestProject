using OpenQA.Selenium;
using Selenium_TestFrameWork;
using Selenium_TestFrameWork.WebDriverExtention;
using Tests.Entities;

namespace Tests.PageObject
{
    class AccountsPage : BasePage<AccountsPage>
    {
        #region IWebElements
        private readonly By NewAccountBtn = By.CssSelector("a[class='forceActionLink'][title='New']"); //new account button
        private readonly By AccountDetailsBtn = By.XPath("//div[contains(@class, 'windowViewMode-normal oneContent active')]//li[@title='Details']");
        private readonly string AccountDetailsField = "//div[@class='slds-form']//span[contains(text(),'{0}')]/../following-sibling::div//lightning-formatted-text";
        private readonly string AccountNameLink = "(//a[@title='{0}'])[1]"; //find account by account name
        #endregion IWebElements

        public AccountsPage(IWebDriver _driver) : base(_driver)
        {
            LogHelper.log.Info("Initialized : " + GetType().Name);
        }

        override public string PageUrl { get; set; } = "https://mycompany-63e-dev-ed.lightning.force.com/lightning/o/Account/list?filterName=Recent";
        override public string PageTitle { get; set; } = "Recently Viewed | Accounts | Salesforce";

        #region Actions
        public NewAccountPage ClickNewAccountBtn()
        {
            driver.WaitForTitle(PageTitle);
            driver.ClickButton(NewAccountBtn);
            return new NewAccountPage(driver);
        }

        public AccountsPage AddNewAccount(Account account)
        {
            ClickNewAccountBtn().FillAndSaveNewAccount(account);
            return ClickAccountsBtn();
        }

        public Account GetAccount(string accountName)
        {
            LogHelper.log.Info("Getting account by accountName");
            driver.WaitForTitle(PageTitle);
            var formatedXPath = string.Format(AccountNameLink, accountName);
            driver.ClickButton(By.XPath(formatedXPath));
            driver.WaitForTitle($"{accountName} | Salesforce");
            driver.ClickButton(AccountDetailsBtn);
            Account account = new();
            foreach (var piInstance in account.GetType().GetProperties())
            {
                formatedXPath = string.Format(AccountDetailsField, piInstance.Name);
                piInstance.SetValue(account, driver.GetElement(By.XPath(formatedXPath)).Text);
            }
            return account;
        }
        #endregion Actions 
    }
}