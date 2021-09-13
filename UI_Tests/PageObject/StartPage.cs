using OpenQA.Selenium;
using Selenium_TestFrameWork;
using Selenium_TestFrameWork.Configuration;
using Selenium_TestFrameWork.WebDriverExtention;

namespace UI_Tests.PageObject
{
    class StartPage
    {
        #region IWebElements
        private readonly By LoginBtn = By.CssSelector("div[role='button'] a[href='https://login.salesforce.com/']");
        private readonly By Shadow_Root = By.CssSelector("hgf-globalnavigation");
        #endregion IWebElements
        private readonly IWebDriver driver;
        private readonly LoginPage loginPage;

        public StartPage(IWebDriver _driver)
        {
            LogHelper.log.Info("initialized : " + this.GetType().Name);
            driver = _driver;
            loginPage = new LoginPage(_driver);
        }
       
        public string PageUrl { get; set; } = Config.WebSite;

        #region Actions
        public StartPage LoadPageByUrl()
        {
            driver.NavigateToUrl(PageUrl);
            return this;
        }

        public HomePage ClickLoginBtnAndLogIn(string userName = null, string password = null)
        {
            LogHelper.log.Info("ClickLoginBtn: " + LoginBtn.ToString());
            driver.GetShadowRoot(Shadow_Root).GetElement(LoginBtn).ClickButton();
            loginPage.LogIn(userName, password);
            return new HomePage(driver);
        }
        #endregion Actions 
    }
}
