using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Threading;

namespace Selenium_TestFrameWork.WebDriverExtention
{
    public static class MouseAction
    {

        public static IWebElement ele;

        public static void MouseRightClick(this IWebDriver driver, By locator)
        {
            Actions act = new Actions(driver);
            ele = driver.FindElement(locator);

            act.ContextClick(ele).Build().Perform();
            Thread.Sleep(3000);
        }
        
        public static void DragNDrop(this IWebDriver driver, By startElement, By endElement)
        {
            Actions act = new Actions(driver);
            IWebElement start = driver.GetElement(startElement);
            IWebElement target = driver.GetElement(endElement);
            act.DragAndDrop(start, target).Build().Perform();
            Thread.Sleep(3000);
        }        

        public static void ClickHoldAndDrag(this IWebDriver driver, By startElement, By endElement)
        {
            Actions act = new Actions(driver);
            IWebElement start = driver.GetElement(startElement);
            IWebElement target = driver.GetElement(endElement);
            act.ClickAndHold(start).MoveToElement(target).Release().Build().Perform();
            Thread.Sleep(3000);
        }
    }
}
