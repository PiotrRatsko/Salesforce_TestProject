using OpenQA.Selenium;
using Selenium_TestFrameWork.Configuration;
using System.Collections.Generic;

namespace Selenium_TestFrameWork.WebDriverExtention
{
    public static class FindWebElement
    {
        private static IList<IWebElement> FindElements<T>(this T type, By locator, int totalSeconds) where T: ISearchContext
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
    }
}
