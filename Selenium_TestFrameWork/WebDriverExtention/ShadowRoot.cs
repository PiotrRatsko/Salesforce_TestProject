using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using System.Collections.ObjectModel;

namespace Selenium_TestFrameWork.WebDriverExtention
{
    public static class ShadowRoot
    {
        public static IWebElement GetShadowRoot(this IWebDriver driver, By locator)
        {
            LogHelper.log.Info("Get shadow root: " + locator.ToString());
            return driver.ExecuteJavaScript<ReadOnlyCollection<IWebElement>>("return arguments[0].shadowRoot.children", driver.GetElement(locator))[1];
        }
    }
}

