﻿using OpenQA.Selenium;
using Selenium_TestFrameWork.WebDriverExtention;
using UI_Tests.BaseClass;

namespace UI_Tests.PageObject
{
    public class Cars : BasePage
    {
        #region IWebElements
        public By PickupLocationTbox => By.Id("car-pickup-clp"); // Picking up      
        public By DropoffLocationTbox => By.Id("car-dropoff-clp"); // Dropping Off
        public By PickupDateTbox => By.Id("car-pickup-date-clp"); // Pick-up date    
        public By PickupTimeDDL => By.Id("car-pickup-time-clp"); // Pick-up time
        public By DropoffDateTbox => By.Id("car-dropoff-date-clp"); // Drop-off date     
        public By DropoffTimeDDL => By.Id("car-dropoff-time-clp"); // Drop-off time

        #region AdvancedOptions
        //Advanced Options
        public By AdvancedOptionsLnk => By.XPath("//a[@href='#cars-adv-options-clp']"); // Advanced options
        public By CarTypeDDL => By.Id("car-options-type-clp"); // Infant seat
        public By RentalCarCompanyDDL => By.Id("car-options-vendor-clp"); // Ski rack
        public By DiscountDLL => By.Id("car-options-discount-clp"); // Left hand control
        public By InfantSeatChbx => By.Id("car-options-equipment-infantseat-clp"); // Toddler seat
        public By SkiRackChbx => By.Id("car-options-equipment-skirack-clp"); // Ski rack
        public By LeftHandControlChbx => By.Id("car-options-equipment-lefthand-clp"); // Left hand control
        public By ToddlerSeatChbx => By.Id("car-options-equipment-toddlerseat-clp"); // Toddler seat
        public By SnowChainsChbx => By.Id("car-options-equipment-chains-clp"); // Snow chains
        public By RightNandControlChbx => By.Id("car-options-equipment-righthand-clp"); // Right hand control
        public By NavigationSystemChbx => By.Id("car-options-equipment-navigation-clp"); // Navigation system
        public By SearchCarBtn => By.XPath("//button[.='Search']"); // Pick-up time

        #endregion AdvancedOptions

        #endregion IWebElements

        public Cars(IWebDriver _driver) : base(_driver)
        { }

        #region Actions
        public void SearchForRentalCarWithAdvancedOptions(string pickupLocation, string pickupDate, int pickupTime,
                                       string dropoffDate, int dropoffTime, string dropofflocation = "")
        {
            driver.TypeInTextBox(PickupLocationTbox, pickupLocation);
            driver.TypeInTextBox(DropoffLocationTbox, dropofflocation);
            driver.TypeInTextBox(PickupDateTbox, pickupDate);
            driver.SelectElementByIndex(PickupTimeDDL, pickupTime);
            driver.TypeInTextBox(DropoffDateTbox, dropoffDate);
            driver.SelectElementByIndex(DropoffTimeDDL, dropoffTime);
            driver.ClickButton(AdvancedOptionsLnk);
        }
        #endregion Actions
    }
}
