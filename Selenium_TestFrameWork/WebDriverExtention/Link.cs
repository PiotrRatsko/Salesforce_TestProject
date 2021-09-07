using OpenQA.Selenium;

namespace Selenium_TestFrameWork.WebDriverExtention
{
    public static class Link
    {
        private static IWebElement element;
        public static void ClickLink(this IWebDriver driver, By locator)
        {
            element = driver.GetElement(locator);
            element.Click();
        }
    }
}
