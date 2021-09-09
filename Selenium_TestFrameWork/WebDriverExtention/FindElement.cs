using OpenQA.Selenium;
using System;

namespace Selenium_TestFrameWork.WebDriverExtention
{
    public static class FindElement
    {
        public static bool IsElementPresent(this IWebDriver driver, By locator)
        {
            try
            {
                return driver.FindElements(locator).Count == 1;
            }
            catch (Exception)
            {
                LogHelper.log.Error("Locator did not find: " + locator.ToString());
                return false;
            }
        }

        public static bool IsElementPresent(this IWebElement webElement, By locator)
        {
            try
            {
                return webElement.FindElements(locator).Count == 1;
            }
            catch (Exception)
            {
                LogHelper.log.Error("Locator did not find: " + locator.ToString());
                return false;
            }
        }
        public static IWebElement GetElement(this IWebDriver driver, By locator)
        {
            if (driver.IsElementPresent(locator))
            {
                return driver.FindElement(locator);
            }
            else
            {
                throw new NoSuchElementException("Element Not Found: " + locator.ToString());
            }
        }

        public static IWebElement GetElement(this IWebElement webElement, By locator)
        {
            if (webElement.IsElementPresent(locator))
            {
                return webElement.FindElement(locator);
            }
            else
            {
                throw new NoSuchElementException("Element Not Found: " + locator.ToString());
            }
        }
    }
}
