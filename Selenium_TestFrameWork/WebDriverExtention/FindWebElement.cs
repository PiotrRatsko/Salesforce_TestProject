using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Selenium_TestFrameWork.Configuration;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Selenium_TestFrameWork.WebDriverExtention
{
    public static class FindWebElement
    {
        private static IList<IWebElement> FindElements<T>(this T type, By locator, int totalSeconds) where T : ISearchContext
        {
            type.WaitForElements(locator, totalSeconds);
            return type.FindElements(locator);
        }

        private static bool IsElementPresent<T>(this T type, By locator, int totalSeconds) where T : ISearchContext
        {
            return type.FindElements(locator, totalSeconds).Count == 1;
        }

        public static IWebElement GetElement(this IWebDriver driver, By locator)
        {

            if (driver.IsElementPresent<IWebDriver>(locator, Config.ElementLoadTimeout))
            {
                return driver.FindElement(locator);
            }
            else
            {
                LogHelper.log.Error("Locator did not find: " + locator.ToString());
                throw new NoSuchElementException("Element Not Found: " + locator.ToString());
            }
        }

        public static IWebElement GetElement(this IWebElement webElement, By locator)
        {
            if (webElement.IsElementPresent(locator, Config.ElementLoadTimeout))
            {
                return webElement.FindElement(locator);
            }
            else
            {
                LogHelper.log.Error("Locator did not find: " + locator.ToString());
                throw new NoSuchElementException("Element Not Found: " + locator.ToString());
            }
        }

        public static IList<IWebElement> TryGetElements(this IWebDriver driver, By locator, int totalMilliseconds = 0)
        {
            Thread.Sleep(totalMilliseconds);
            LogHelper.log.Info("Try to get WebElements: " + locator.ToString());
            return driver.FindElements(locator);
        }
    }
}
