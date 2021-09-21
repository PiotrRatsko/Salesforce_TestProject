using OpenQA.Selenium;
using Selenium_TestFrameWork;
using Tests.Entities;
using Tests.PageObject.Abstracts;

namespace Tests.PageObject
{
    class ContactsPage : BasePage<ContactsPage>
    {
        #region IWebElements
        public override By PageButton { get; set; } = By.XPath("//a[@title='Contacts']");
        #endregion IWebElements

        public ContactsPage(IWebDriver _driver) : base(_driver)
        {
            NewSObjectPage = new NewContactPage(_driver);
            Entity = new Contact();
            SObjectPage = new ContactPage(_driver);
            LogHelper.log.Info("Initialized : " + GetType().Name);
        }

        override public string PageUrl { get; set; } = "https://mycompany-63e-dev-ed.lightning.force.com/lightning/o/Contact/list?filterName=Recent";
        override public string PageTitle { get; set; } = "Recently Viewed | Contacts | Salesforce";
        public override NewSObjectPage NewSObjectPage { get; set; }
        public override IEntity Entity { get; set; }
        public override SObjectPage SObjectPage { get; set; }

        #region Actions
        #endregion Actions 
    }
}
