﻿using OpenQA.Selenium;

namespace Selenium_TestFrameWork.WebDriverExtention
{
    public static class Browser
    {
        public static void MaxBrowser(this IWebDriver driver)
        {
            LogHelper.log.Info("Max browser");
            driver.Manage().Window.Maximize();
        }

        public static void GoFoward(this IWebDriver driver)
        {
            driver.Navigate().Forward();
        }

        public static void GoBack(this IWebDriver driver)
        {
            driver.Navigate().Back();
        }

        public static void RefreshPage(this IWebDriver driver)
        {
            driver.Navigate().Refresh();
        }

        public static void SwitchToFrame(this IWebDriver driver, By locator)
        {
            driver.SwitchTo().Frame(driver.GetElement(locator));
        }
    }
}
