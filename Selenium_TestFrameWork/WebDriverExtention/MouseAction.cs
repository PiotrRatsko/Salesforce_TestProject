using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Threading;

namespace Selenium_TestFrameWork.WebDriverExtention
{
    public static class MouseAction
    {
        public static void MouseRightClick(this IWebDriver driver, By locator)
        {
            Actions act = new Actions(driver);
            IWebElement ele = driver.GetElement(locator);
            act.ContextClick(ele).Build().Perform();
        }
        
        public static void DragNDrop(this IWebDriver driver, By startElement, By endElement)
        {
            Actions act = new Actions(driver);
            IWebElement start = driver.GetElement(startElement);
            IWebElement target = driver.GetElement(endElement);
            act.DragAndDrop(start, target).Build().Perform();
        }        

        public static void ClickHoldAndDrag(this IWebDriver driver, By startElement, By endElement)
        {
            Actions act = new Actions(driver);
            IWebElement start = driver.GetElement(startElement);
            IWebElement target = driver.GetElement(endElement);
            act.ClickAndHold(start).MoveToElement(target).Release().Build().Perform();
        }
    }
}
