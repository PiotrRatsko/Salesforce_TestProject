using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Selenium_TestFrameWork.WebDriverExtention
{
    public static class WaitHelper
    {

        public static void WaitForTitle(this IWebDriver driver, string title, int totalSeconds = 30, int checkInterval = 250)
        {
            try
            {
                LogHelper.log.Info("Watting page title: " + title);
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(totalSeconds));
                wait.PollingInterval = TimeSpan.FromMilliseconds(checkInterval);
                wait.Until(x => x.Title.Contains(title));
            }
            catch
            {
                LogHelper.log.Error("Did not manage title: " + title);
            }
        }

        // Once the element is visible, return that element
        //public static IWebElement WaitForElement(By locator, int totalSeconds, int checkInterval)
        //{
        //    ObjectRepository.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
        //    WebDriverWait wait = new WebDriverWait(ObjectRepository.Driver, TimeSpan.FromSeconds(totalSeconds));
        //    wait.PollingInterval = TimeSpan.FromMilliseconds(checkInterval);
        //    wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException));
        //    wait.Until(ExpectedConditions.ElementIsVisible(locator));
        //    IWebElement element = GenericHelper.GetElement(locator);
        //    return element;
        //}

        //// Use this wait for Auto Suggest List and get all the list
        //public static IList<IWebElement> WaitForAutoSuggestList(By locator, int totalSeconds, int checkInterval)
        //{
        //    ObjectRepository.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
        //    WebDriverWait wait = new WebDriverWait(ObjectRepository.Driver, TimeSpan.FromSeconds(totalSeconds))
        //    {
        //        PollingInterval = TimeSpan.FromMilliseconds(checkInterval),
        //    };
        //    wait.Until(ExpectedConditions.ElementIsVisible(locator));
        //    return wait.Until(GetAllElements(locator));
        //}

        //private static Func<IWebDriver, IList<IWebElement>> GetAllElements(By locator)
        //{
        //    return ((x) =>
        //    {
        //        return x.FindElements(locator);
        //    });
        //}
    }
}
