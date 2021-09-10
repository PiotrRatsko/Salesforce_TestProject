using OpenQA.Selenium;
using Selenium_TestFrameWork;
using Selenium_TestFrameWork.WebDriverExtention;

namespace UI_Tests.PageObject
{
    public class StartPage
    {
        private readonly IWebDriver driver;
        public StartPage(IWebDriver _driver)
        {
            driver = _driver;
            LogHelper.log.Info("initialized : " + this.GetType().Name);
        }
        #region IWebElements
        private readonly By LoginBtn = By.CssSelector("div[role='button'] a[href='https://login.salesforce.com/']");
        private readonly By Shadow_Root = By.CssSelector("hgf-globalnavigation");
        #endregion IWebElements

        #region Actions
        public LoginPage GetLoginPage()
        {
            driver.GetShadowRoot(Shadow_Root).GetElement(LoginBtn).ClickButton();
            LogHelper.log.Info("ClickButton: " + LoginBtn.ToString());
            return new LoginPage(driver);
        }
        #endregion Actions 
    }
}
