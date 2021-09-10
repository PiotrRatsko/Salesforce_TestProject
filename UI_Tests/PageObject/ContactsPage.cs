using OpenQA.Selenium;
using Selenium_TestFrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI_Tests.PageObject
{
    public class ContactsPage : BasePage
    {
        public ContactsPage(IWebDriver _driver) : base(_driver)
        {
            LogHelper.log.Info("initialized : " + this.GetType().Name);
        }

        #region IWebElements
        //private readonly By LoginBtn = By.CssSelector("div[role='button'] a[href='https://login.salesforce.com/']");
        //private readonly By Shadow_Root = By.CssSelector("hgf-globalnavigation");
        #endregion IWebElements

        #region Actions
        #endregion Actions 
    }
}
