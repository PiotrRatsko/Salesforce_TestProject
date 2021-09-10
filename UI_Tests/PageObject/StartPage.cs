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
            LogHelper.log.Info("initialized : " + this.GetType().Name);
            driver = _driver;
        }
        #region IWebElements
        private readonly By LoginBtn = By.CssSelector("div[role='button'] a[href='https://login.salesforce.com/']");
        private readonly By Shadow_Root = By.CssSelector("hgf-globalnavigation");
        #endregion IWebElements

        #region Actions
        public LoginPage GetLoginPage()
        {
            LogHelper.log.Info("ClickButton: " + LoginBtn.ToString());
            driver.GetShadowRoot(Shadow_Root).GetElement(LoginBtn).ClickButton();
            return new LoginPage(driver);
        }
        #endregion Actions 
    }
}
