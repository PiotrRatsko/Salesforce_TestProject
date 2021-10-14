using OpenQA.Selenium;

namespace Selenium_TestFrameWork.WebDriverExtention
{
    public static class RadioButton
    {
        public static bool IsRadioButtonSelected(this IWebDriver driver, By locator)
        {
            IWebElement element = driver.GetElement(locator);
            string flag = element.GetAttribute("checked");
            if (flag == null)
                return false;
            else
                return flag.Equals("true") || flag.Equals("checked");
        }

        public static void ClickRadioButton(this IWebDriver driver, By locator)
        {
            IWebElement element = driver.GetElement(locator);
            element.Click();
        }
    }
}
