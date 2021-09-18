using OpenQA.Selenium;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Support.Extensions;
using System.Threading;

namespace Selenium_TestFrameWork.WebDriverExtention
{
    public static class Button
    {
        private static IWebElement element;

        public static void ClickButton(this IWebDriver driver, By locator)
        {
            Thread.Sleep(1000);
            IWebElement element = driver.GetElement(locator);
            driver.ExecuteJavaScript("arguments[0].click();", element);
            LogHelper.log.Info("Click button: " + locator.ToString());
        }

        public static void ClickButton(this IWebElement element)
        {
            ((IWrapsDriver)element).WrappedDriver.ExecuteJavaScript("arguments[0].click();", element);
            LogHelper.log.Info("Click button: " + element);
        }

        public static string GetButtonText(this IWebDriver driver, By locator)
        {
            element = driver.GetElement(locator);
            if (element.GetAttribute("value") == null)
            {
                return string.Empty;
            }
            else
                return element.GetAttribute("value");
        }
    }
}
