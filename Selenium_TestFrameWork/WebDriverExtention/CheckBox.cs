using OpenQA.Selenium;

namespace Selenium_TestFrameWork.WebDriverExtention
{
    public static class CheckBox
    {
        private static IWebElement element;
        public static bool IsCheckBoxChecked(this IWebDriver driver, By locator)
        {
            element = driver.GetElement(locator);
            string flag = element.GetAttribute("checked");
            if (flag == null)
                return false;
            else
                return flag.Equals("true") || flag.Equals("checked");
        }
        public static void CheckOnCheckBox(this IWebDriver driver, By locator)
        {
            element = driver.GetElement(locator);
            element.Click();
        }
    }
}
