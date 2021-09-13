﻿using OpenQA.Selenium;
using Selenium_TestFrameWork;

namespace UI_Tests.PageObject
{
     class ContactsPage : BasePage<ContactsPage>
    {
        #region IWebElements
        #endregion IWebElements

        public ContactsPage(IWebDriver _driver) : base(_driver)
        {
            LogHelper.log.Info("Initialized : " + this.GetType().Name);
        }

        override public string PageUrl { get; set; } = "https://itechart-c.lightning.force.com/lightning/o/Contact/list?filterName=Recent";
        override public string PageTitle { get; set; } = "Recently Viewed | Contacts | Salesforce";

        #region Actions
        #endregion Actions 
    }
}
