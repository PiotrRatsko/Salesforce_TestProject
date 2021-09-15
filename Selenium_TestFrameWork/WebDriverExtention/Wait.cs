using OpenQA.Selenium;
using OpenQA.Selenium.Internal;
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
                WebDriverWait wait = new(driver, TimeSpan.FromSeconds(totalSeconds));
                wait.PollingInterval = TimeSpan.FromMilliseconds(checkInterval);
                wait.Until(x => x.Title.Contains(title));
            }
            catch
            {
                LogHelper.log.Error("Did not manage title: " + title);
                throw new Exception("Did not manage title: " + title);
            }
        }

        // Use this wait for Web element or elements
        public static void WaitForElements<T>(this T type, By locator, int totalSeconds, int checkInterval = 250)
        {
            try
            {
                WebDriverWait wait;
                LogHelper.log.Info("Waitting for webelement: " + locator.ToString());
                if (type.GetType().Name == "RemoteWebElement")
                {
                    wait = new(((IWrapsDriver)type).WrappedDriver, TimeSpan.FromSeconds(totalSeconds));
                    wait.PollingInterval = TimeSpan.FromMilliseconds(checkInterval);
                    wait.Until(x => (type as IWebElement).FindElements(locator).Count > 0);
                    return;
                }
                wait = new(type as IWebDriver, TimeSpan.FromSeconds(totalSeconds));
                wait.PollingInterval = TimeSpan.FromMilliseconds(checkInterval);
                wait.Until(x => x.FindElements(locator).Count > 0);
            }
            catch
            {
                LogHelper.log.Error("Did not find webelement: " + locator.ToString());
                throw new Exception("Did not find webelement: " + locator.ToString());
            }
        }
    }
}
