using OpenQA.Selenium;
using Selenium_TestFrameWork;
using Selenium_TestFrameWork.WebDriverExtention;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI_Tests.PageObject
{
    public class AccountsPage : BasePage<AccountsPage>, IPageWithUrl
    {
        public AccountsPage(IWebDriver _driver) : base(_driver)
        {
            LogHelper.log.Info("initialized : " + this.GetType().Name);
        }

        #region IWebElements
        public string PageUrl { get; set; } = "https://itechart-c.lightning.force.com/lightning/o/Account/list?filterName=Recent";
        //private readonly By LoginBtn = By.CssSelector("div[role='button'] a[href='https://login.salesforce.com/']");
        //private readonly By Shadow_Root = By.CssSelector("hgf-globalnavigation");
        #endregion IWebElements

        #region Actions
        
        #endregion Actions 
    }
}
