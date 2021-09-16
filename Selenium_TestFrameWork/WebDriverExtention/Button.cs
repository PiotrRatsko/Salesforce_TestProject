using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Internal;
using System.Drawing;
using System.Threading;

namespace Selenium_TestFrameWork.WebDriverExtention
{
    public static class Button
    {
        private static IWebElement element;

        public static void ClickButton(this IWebDriver driver, By locator)
        {
            LogHelper.log.Info("Click button: " + locator.ToString());
            Thread.Sleep(1000);
            IWebElement element = driver.GetElement(locator);
            element.Click();
        }

        public static void ClickButton(this IWebElement element)
        {
            LogHelper.log.Info("Click button: " + element);
            element.Click();
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
