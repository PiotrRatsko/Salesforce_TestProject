﻿using OpenQA.Selenium;
using Selenium_TestFrameWork.WebDriverExtention;
using UI_Tests.PageObject;

namespace UI_Tests.BaseClass
{
    public class BasePage
    {
        protected IWebDriver driver;
        public BasePage(IWebDriver _driver)
        {
            driver = _driver;
        }
        #region IWebElements

        #region Main Header Menus
        public By Home_Hmenu = By.Id("primary-header-home"); //Home
        public By Hotels_Hmenu = By.Id("primary-header-hotel"); //Hotel
        public By Flights_Hmenu = By.Id("primary-header-flight"); //Flights
        public By Packages_Hmenu = By.Id("primary-header-package"); //Packages
        public By Cars_Hmenu = By.Id("primary-header-car"); // Cars
        public By VacationRentals_Hmenu = By.Id("primary-header-vacationRental"); //Vacation Rentals
        public By Cruises_Hmenu = By.Id("primary-header-cruises"); //Cruises
        public By Deals_Hmenu = By.Id("primary-header-deals"); //Deals
        public By Activities_Hmenu = By.Id("primary-header-activity"); //Activities
        public By Discover_Hmenu = By.Id("primary-header-discover"); //Discover
        public By Mobile_Hmenu = By.Id("primary-header-mobile"); //Mobile
        public By Rewards_Hmenu = By.Id("primary-header-rewards"); //Rewards
        public By TravelBlog_Hmenu = By.Id("primary-header-blog"); //Travel Blog

        #endregion Main Header Menus

        #region Header Menus
        public By AccountMenu = By.Id("header-account-menu"); //Account        
        public By HelloUserMenu = By.Id("header-account-menu-signed-in"); // Hello, User
        public By SignInMenuBtn = By.Id("header-account-signin-button"); //Sign In         
        public By AccountSignOutLnk = By.Id("account-signout"); // Sign Out
        public By CreateAccountLnk = By.Id("header-account-register"); // Create an Account
        public By MyListsLnk = By.Id("header-history"); //My Lists
        public By MyTripsLnk = By.Id("header-itineraries"); //My Trips
        public By SupportLnk = By.Id("header-support-menu"); // Support
        public By CustomerSupportLnk = By.Id("support-cs"); // Customer Support
        public By FeedbackLnk = By.Id("support-feedback"); // Feedback
        public By EspanolLnk = By.Id("header-language-2058"); // Espanol
        public By JoinRewardsLnk = By.Id("header-language-2058"); // Join Rewards

        #endregion Header Menus

        #endregion IWebElements

        #region Actions
        public void SignOut()
        {
            driver.ClickButton(HelloUserMenu);
            driver.ClickLink(AccountSignOutLnk);
        }

        #region Navigation

        public LoginPage NavigateToSignIn()
        {
            driver.ClickButton(AccountMenu);
            driver.ClickButton(SignInMenuBtn);
            return new LoginPage(driver);
        }
        #endregion Navigation

        #endregion Actions
    }
}