using OpenQA.Selenium;

namespace Selenium_TestFrameWork.WebDriverExtention
{
    public static class Navigation
    {
        public static void NavigateToUrl(this IWebDriver driver, string url)
        {
            LogHelper.log.Info("Navigate to URL: " + url);
            driver.Navigate().GoToUrl(url);
        }
    }
}
