using OpenQA.Selenium;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Support.Extensions;
using System.Threading;

namespace Selenium_TestFrameWork.WebDriverExtention
{
    public static class Button
    {
        public static void ClickButton(this IWebDriver driver, By locator, int sleepTime = 1000)
        {
            LogHelper.log.Info("Click button: " + locator.ToString());
            IWebElement element = driver.GetElement(locator);
            element.ClickButton(sleepTime);
        }

        public static void ClickButton(this IWebElement element, int sleepTime = 0)
        {
            ((IWrapsDriver)element).WrappedDriver.ExecuteJavaScript("arguments[0].click();", element);
            LogHelper.log.Info("Click button: " + element);
            Thread.Sleep(sleepTime);
            ((IWrapsDriver)element).WrappedDriver.WaitAuraCompete();
        }

        public static string GetButtonText(this IWebDriver driver, By locator)
        {
            IWebElement element = driver.GetElement(locator);
            if (element.GetAttribute("value") == null)
            {
                return string.Empty;
            }
            else
                return element.GetAttribute("value");
        }
    }
}
