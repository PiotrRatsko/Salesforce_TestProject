using OpenQA.Selenium;

namespace Selenium_TestFrameWork.WebDriverExtention
{
    public static class JavaScriptPopup
    {
        public static bool IsPopupPresent(this IWebDriver driver)
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        public static string GetPopupText(this IWebDriver driver)
        {
            if (!driver.IsPopupPresent())
            {
                return "";
            }
            return driver.SwitchTo().Alert().Text;
        }

        //OK button
        public static void ClickOKOnPopup(this IWebDriver driver)
        {
            if (!driver.IsPopupPresent())
                return;
            driver.SwitchTo().Alert().Accept();
        }

        // Dismiss button
        public static void ClickDismissOnPopup(this IWebDriver driver)
        {
            if (!driver.IsPopupPresent())
                return;
            driver.SwitchTo().Alert().Dismiss();
        }

        public static void SendKeys(this IWebDriver driver, string text)
        {
            if (!driver.IsPopupPresent())
                return;
            driver.SwitchTo().Alert().SendKeys(text);
        }
    }
}

