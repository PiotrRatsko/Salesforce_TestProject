using OpenQA.Selenium;

namespace Selenium_TestFrameWork.WebDriverExtention
{
    public static class TextBox
    {
        public static void TypeInTextBox(this IWebDriver driver, By locator, string inputText)
        {
            LogHelper.log.Info("Send keys: " + locator.ToString());
            driver.GetElement(locator).SendKeys(inputText);
        }

        public static void ClearTextBox(this IWebDriver driver, By locator)
        {
            LogHelper.log.Info("Clear text box: " + locator.ToString());
            driver.GetElement(locator).Clear();
        }
    }
}
