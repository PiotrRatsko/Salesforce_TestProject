using OpenQA.Selenium;

namespace Selenium_TestFrameWork.WebDriverExtention
{
    public static class TextBox
    {
        private static IWebElement element;
        public static void TypeInTextBox(this IWebDriver driver, By locator, string inputText)
        {
            driver.ClearTextBox(locator);
            LogHelper.log.Info("Send keys: " + locator.ToString());
            element.SendKeys(inputText);
        }

        public static void ClearTextBox(this IWebDriver driver, By locator)
        {
            LogHelper.log.Info("Clear text box: " + locator.ToString());
            element = driver.GetElement(locator);
            element.Clear();
        }
    }
}
