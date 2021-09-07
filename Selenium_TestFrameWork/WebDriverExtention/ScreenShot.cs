using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using Selenium_TestFrameWork.Configuration;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Selenium_TestFrameWork.WebDriverExtention
{
    public static class ScreenShot
    {
        public static string TakeScreenShot(this IWebDriver driver, string fileName = "Screenshot")
        {
            // if there is no storage folder, create
            Directory.CreateDirectory(Config.ScreenshotStorage);

            Screenshot screen = driver.TakeScreenshot();
            fileName = fileName + DateTime.Now.ToString("yyyyMMdd hhmmss") + ".png";
            string path = Config.ScreenshotStorage + "\\" + fileName;

            screen.SaveAsFile(path, ScreenshotImageFormat.Png);
            return path;
        }
    }
}
