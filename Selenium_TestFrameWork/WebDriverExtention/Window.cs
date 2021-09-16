using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;
using System.Threading;

namespace Selenium_TestFrameWork.WebDriverExtention
{
    public static class Window
    {
        public static string GetPageTitle(this IWebDriver driver)
        {
            WebDriverWait wait = new(driver, TimeSpan.FromSeconds(30));
            wait.PollingInterval = TimeSpan.FromMilliseconds(250);
            wait.IgnoreExceptionTypes(typeof(Exception));
            wait.Until(x => x.FindElement(By.XPath("/html/head/title[1]")));
            LogHelper.log.Info("Got page title: " + driver.Title);
            return driver.Title;
        }

        // Switch the window 
        public static void SwitchToWindow(this IWebDriver driver, int index = 0)
        {
            ReadOnlyCollection<string> windows = driver.WindowHandles;
            if (windows.Count < index)
            {
                throw new NoSuchWindowException("Invalid Browser Window Index " + index);
            }
            driver.SwitchTo().Window(windows[index]);
            Thread.Sleep(1000);
            driver.MaxBrowser();
        }

        // close all the child windows and go back to the parent window.
        public static void SwitchToParent(this IWebDriver driver)
        {
            var windowsids = driver.WindowHandles;
            for (int i = windowsids.Count - 1; i > 0; i--)
            {
                driver.SwitchTo().Window(windowsids[i]);
                driver.Close();
            }
            driver.SwitchTo().Window(windowsids[0]);
        }

        // input: iframe id
        public static void SwitchToiFrame(this IWebDriver driver, By locator)
        {
            driver.SwitchTo().Frame(driver.GetElement(locator));
        }

        public static void SwitchToMainFrame(this IWebDriver driver)
        {
            driver.SwitchTo().DefaultContent();
        }
    }
}
