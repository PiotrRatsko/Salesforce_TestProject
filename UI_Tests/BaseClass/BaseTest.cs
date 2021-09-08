using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using Selenium_TestFrameWork.WebDriverExtention;
using Selenium_TestFrameWork.Configuration;
using Selenium_TestFrameWork.CustomException;
using System;
using Selenium_TestFrameWork;
using NUnit.Allure.Core;
using Allure.Commons;
using System.IO;

namespace UI_Tests.BaseClass
{
    [AllureNUnit]
    [Parallelizable(scope: ParallelScope.Fixtures)]
    public class BaseTest
    {
        protected IWebDriver driver;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            AllureLifecycle.Instance.CleanupResultDirectory();

            driver = Config.BrowserType switch
            {
                BrowserType.Firefox => new FirefoxDriver(),
                BrowserType.Chrome => new ChromeDriver(Directory.GetCurrentDirectory()),
                BrowserType.IExplorer => new InternetExplorerDriver(),
                _ => throw new NoSuitableDriverFound("Driver Not Found: {0}" + Config.BrowserType.ToString()),
            };
            LogHelper.log.Info("InitWebDriver: " + Config.BrowserType);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(Config.PageLoadTimeout);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Config.ElementLoadTimeout);

            driver.NavigateToUrl(Config.WebSite);
            driver.MaxBrowser();
        }

        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status.ToString().Equals("Passed"))
            {
            }
            else if (TestContext.CurrentContext.Result.Outcome.Status.ToString().Equals("Failed"))
            {
                string path = driver.TakeScreenShot();
                AllureLifecycle.Instance.AddAttachment("ScreenShot", "screenshot/Png", path);
            }
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            if (driver != null)
            {
                driver.Close();
                driver.Quit();
            }
        }
    }
}
