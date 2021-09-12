//using OpenQA.Selenium;
//using Selenium_TestFrameWork;
//using Selenium_TestFrameWork.Configuration;
//using Selenium_TestFrameWork.WebDriverExtention;
//using System;

//namespace UI_Tests.PageObject
//{
//    public class StartPage : LoginPage<HomePage>, IPageLoader<StartPage>
//    {
//        public StartPage LoadPageByUrl()
//        {
//            driver.NavigateToUrl(PageUrl);
//            return this;
//        }
//        private readonly IWebDriver driver;
//        public string PageUrl { get; set; } = Config.WebSite;

//        public StartPage(IWebDriver _driver) : base(_driver)
//        {
//            LogHelper.log.Info("initialized : " + this.GetType().Name);
//            driver = _driver;
//        }
//        #region IWebElements
//        private readonly By LoginBtn = By.CssSelector("div[role='button'] a[href='https://login.salesforce.com/']");
//        private readonly By Shadow_Root = By.CssSelector("hgf-globalnavigation");
//        #endregion IWebElements

//        #region Actions
//        public new HomePage LogIn(string userName = null, string password = null)
//        {
//            LogHelper.log.Info("ClickButton: " + LoginBtn.ToString());
//            driver.GetShadowRoot(Shadow_Root).GetElement(LoginBtn).ClickButton();
//            return base.LogIn(userName, password);
//        }
//        #endregion Actions 
//    }
//}
