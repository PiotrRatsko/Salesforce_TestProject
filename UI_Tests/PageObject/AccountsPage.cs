using OpenQA.Selenium;
using Selenium_TestFrameWork;
using Selenium_TestFrameWork.WebDriverExtention;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using UI_Tests.Entities;

namespace UI_Tests.PageObject
{
    class AccountsPage : BasePage<AccountsPage>
    {
        #region IWebElements
        private readonly By NewAccountBtn = By.CssSelector("a[class='forceActionLink'][title='New']"); //new account button
        private readonly By AccountDetailsBtn = By.XPath("//li[@title='Details']");
        private readonly string AccountDetailsField = "//div[@class='slds-form']//span[text()='{0}']/../following-sibling::div//lightning-formatted-text";
        private readonly string AccountNameLink = "(//a[@title='{0}'])[1]"; //find account by account name
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
            driver.GetElement(By.XPath(formatedXPath)).Click();
            driver.WaitForTitle($"{accountName} | Salesforce");
            driver.ClickButton(AccountDetailsBtn);
            Account account = new();
            foreach (var piInstance in account.GetType().GetProperties())
            {
                string propName = piInstance.GetCustomAttribute<DisplayAttribute>()?.Name;
                propName ??= piInstance.Name;
                formatedXPath = string.Format(AccountDetailsField, propName);
                piInstance.SetValue(account, driver.GetElement(By.XPath(formatedXPath)).Text);
            }
            return account;
        }
        #endregion Actions 
    }
}