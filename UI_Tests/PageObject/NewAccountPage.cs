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
        private readonly By SaveBtn = By.XPath("//button[text()='Save']"); //button for save new account
        private readonly By Name = By.XPath("//div[@class ='actionBody']//label[contains(text(),'Name')]/following-sibling::div//input");
        private readonly By TypeBtn = By.XPath("//label[text()='Type']/..//input[@role='combobox']"); //button for expand Type menu
        private readonly string Type = "//div[@id='{0}']//lightning-base-combobox-item[@data-value='{1}']"; //path to choose need type
        private readonly By Description = By.XPath("//div[@class ='actionBody']//label[text()='Description'] /following-sibling::div//textarea");
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
            driver.TypeInTextBox(Name, account.Name);
            SelectElementFromMenu(TypeBtn, Type, account.Type);
            driver.TypeInTextBox(Description, account.Description);
            driver.GetElement(Name).SendKeys(Keys.Enter);
            driver.ClickButton(SaveBtn);
        }

        private void SelectElementFromMenu(By typeBtn, string XPathElementLocator, string elementToAdd)
        {
            driver.ClickButton(typeBtn);
            var formatedXPath = string.Format(XPathElementLocator, driver.GetElement(typeBtn).GetAttribute("aria-owns"), elementToAdd);
            driver.GetElement(By.XPath(formatedXPath)).ClickButton();
        }
        #endregion Actions 
    }
}
