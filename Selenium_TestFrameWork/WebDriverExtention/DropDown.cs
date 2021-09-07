using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Linq;

namespace Selenium_TestFrameWork.WebDriverExtention
{
    public static class DropDown
    {
        public static void SelectElementByIndex(this IWebDriver driver, By locator, int index)
        {
            SelectElement select = new(driver.GetElement(locator));
            select.SelectByIndex(index);
        }
        public static void SelectElementByText(this IWebDriver driver, By locator, string visibleText)
        {
            SelectElement select = new(driver.GetElement(locator));
            select.SelectByText(visibleText);
        }

        public static IList<string> GetAllItems(this IWebDriver driver, By locator)
        {
            SelectElement select = new(driver.GetElement(locator));
            return select.Options.Select(x => x.Text).ToList();
        }
    }
}
