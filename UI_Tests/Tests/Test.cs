﻿using NUnit.Framework;
using Selenium_TestFrameWork;
using System;
using UI_Tests.BaseClass;
using UI_Tests.PageObject;

namespace UI_Tests.Tests
{
    public class Test : BaseTest
    {
        [Test]
        [Retry(2)]
        [Order(1)]
        public void MyTest()
        {
            LogHelper.log.Info("Starting Test: " + TestContext.CurrentContext.Test.Name);
            Home hp = new(driver);
            hp.GetLoginPage();
            //Cars cars = hp.NavigateToCars();
            //log.Info("Navigated To Cars Page");

            //cars.SearchForRentalCarWithAdvancedOptions("LAX", "07/06/2018", 28, "07/09/2018", 12);
            //log.Info("Default Fields Have Been Filled Out");

            //driver.CheckOnCheckBox(cars.NavigationSystemChbx);
            //log.Info("Advanced Options Are Selected");

            //driver.ClickButton(cars.SearchCarBtn);
            //log.Info("Options Are Submitted");
            //log.Info("Verifying the Expected Phrase are displayed");
            //Assert.IsTrue(driver.IsElementPresent(By.XPath("//span[@title='Los Angeles, CA (LAX-Los Angeles Intl.)']")));
        }

        [Test]
        [Retry(2)]
        [Order(2)]
        public void MyTestWrong()
        {
            
        }
    }
}
