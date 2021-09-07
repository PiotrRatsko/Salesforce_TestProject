using OpenQA.Selenium;

namespace Selenium_TestFrameWork.WebDriverExtention
{
    public static class Button
    {
        private static IWebElement element;
        public static bool IsButtonEnabled(this IWebDriver driver, By locator)
        {
            element = driver.GetElement(locator);
            return element.Enabled;
        }

        public static void ClickButton(this IWebDriver driver, By locator)
        {
            //WaitHelper.WaitForElement(locator);
            element = driver.GetElement(locator);
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
