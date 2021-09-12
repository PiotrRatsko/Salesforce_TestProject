using OpenQA.Selenium;
using Selenium_TestFrameWork;

namespace UI_Tests.PageObject
{
    public class ContactsPage : BasePage<ContactsPage>
    {
        override public string PageUrl { get; set; } = "https://itechart-c.lightning.force.com/lightning/o/Contact/list?filterName=Recent";

        public ContactsPage(IWebDriver _driver) : base(_driver)
        {
            LogHelper.log.Info("initialized : " + this.GetType().Name);
        }

        #region IWebElements
        #endregion IWebElements

        #region Actions
        #endregion Actions 
    }
}
