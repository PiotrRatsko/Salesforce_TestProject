using OpenQA.Selenium;
using Selenium_TestFrameWork;
using Selenium_TestFrameWork.WebDriverExtention;
using Tests.Entities;

namespace Tests.PageObject
{
    class NewAccountPage
    {
        private readonly IWebDriver driver;
        #region IWebElements
        private readonly By SaveBtn = By.CssSelector("button[title='Save']"); //button for save new account
        private readonly By AccountName = By.XPath("//div[@class ='actionBody']//span[text()='Account Name']/../following-sibling::div//input");
        private readonly By TypeBtn = By.XPath("//span[text()='Type']/../following-sibling::div[@class='uiMenu']//div[@class='uiPopupTrigger']"); //button for expand Type menu
        private readonly string Type = "//div[@aria-labelledby='{0}']//a[@title='{1}']"; //path to choose need type
        private readonly By Description = By.XPath("//div[@class ='actionBody']//span[text()='Description']/../following-sibling::textarea");
        #endregion IWebElements

        public NewAccountPage(IWebDriver _driver)
        {
            LogHelper.log.Info("Initialized : " + GetType().Name);
            driver = _driver;
        }

        public string PageTitle { get; set; } = "New Account | Salesforce";

        #region Actions
        public void FillAndSaveNewAccount(Account account)
        {
            driver.WaitForTitle(PageTitle);
            driver.TypeInTextBox(AccountName, account.AccountName);
            SelectElementFromMenu(TypeBtn, Type, account.Type);
            driver.TypeInTextBox(Description, account.Description);
            driver.ClickButton(SaveBtn);
        }

        private void SelectElementFromMenu(By menuLocator, string XPathElementLocator, string elementToAdd)
        {
            IWebElement menu = driver.GetElement(menuLocator);
            menu.ClickButton();
            var formatedXPath = string.Format(XPathElementLocator, menu.GetAttribute("id"), elementToAdd);
            driver.GetElement(By.XPath(formatedXPath)).Click();
        }
        #endregion Actions 
    }
}
