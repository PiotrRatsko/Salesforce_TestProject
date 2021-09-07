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
    }
}
