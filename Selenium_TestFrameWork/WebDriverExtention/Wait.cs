using OpenQA.Selenium;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Support.Extensions;
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
                LogHelper.log.Info("Waiting page title: " + title);
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
                LogHelper.log.Info("Waiting for web element: " + locator.ToString());
                if (type.GetType().Name == "RemoteWebElement")
                {
                    wait = new(((IWrapsDriver)type).WrappedDriver, TimeSpan.FromSeconds(totalSeconds));
                    wait.PollingInterval = TimeSpan.FromMilliseconds(checkInterval);
                    ((IWrapsDriver)type).WrappedDriver.WaitAuraCompete();
                    wait.Until(x => (type as IWebElement).FindElements(locator).Count > 0);
                    return;
                }

                wait = new(type as IWebDriver, TimeSpan.FromSeconds(totalSeconds));
                wait.PollingInterval = TimeSpan.FromMilliseconds(checkInterval);
                (type as IWebDriver).WaitAuraCompete();
                wait.Until(x => x.FindElements(locator).Count > 0);
            }
            catch
            {
                LogHelper.log.Error("Did not find web element: " + locator.ToString());
                throw new Exception("Did not find web element: " + locator.ToString());
            }
        }

        public static void WaitAuraCompete(this IWebDriver driver)
        {
            try
            {
                WebDriverWait wait;
                wait = new(driver, TimeSpan.FromSeconds(60));
                wait.PollingInterval = TimeSpan.FromMilliseconds(250);
                if ((driver).ExecuteJavaScript<Boolean>("return (typeof $A !== 'undefined')"))
                {
                    wait.Until(x => x.ExecuteJavaScript<string>("return document.readyState").ToString().Equals("complete"));
                    wait.Until(x => x.ExecuteJavaScript<Boolean>("return ($A && $A.metricsService.getCurrentPageTransaction().config.context.ept > 0)"));
                }
            }
            catch
            {
                LogHelper.log.Error("Aura process did not compete in 60 sec");
                throw new Exception("Aura process did not compete in 60 sec");
            }
        }
    }
}
