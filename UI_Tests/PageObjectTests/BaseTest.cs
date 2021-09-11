using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using Selenium_TestFrameWork.WebDriverExtention;
using Selenium_TestFrameWork.Configuration;
using Selenium_TestFrameWork.CustomException;
using System;
using NUnit.Allure.Core;
using Allure.Commons;
using OpenQA.Selenium.Support.Extensions;

namespace UI_Tests.PageObject.Tests
{
    [AllureNUnit]
    [Parallelizable(scope: ParallelScope.Fixtures)]
    public class BaseTest
    {
        protected IWebDriver driver;
        private static IWebDriver GetChromeDriver()
        {
            ChromeOptions options = new();
            if (Config.ChromeOptions == "--headless")
            {
                options.AddArguments("--headless");
                options.AddArguments("--window-size=1920,1080");
            }
            return new ChromeDriver(options);
        }

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            AllureLifecycle.Instance.CleanupResultDirectory();

            driver = Config.BrowserType switch
            {
                BrowserType.Firefox => new FirefoxDriver(),
                BrowserType.Chrome => GetChromeDriver(),
                BrowserType.IExplorer => new InternetExplorerDriver(),
                _ => throw new NoSuitableDriverFound("Driver Not Found: {0}" + Config.BrowserType.ToString()),
            };
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(Config.PageLoadTimeout);
            //driver.NavigateToUrl(Config.WebSite);
            driver.MaxBrowser();
        }

        [SetUp]
        public void GetConfiguration()
        {
            Config.WriteConfig2Console();
        }

        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status.ToString().Equals("Failed"))
            {
                AllureLifecycle.Instance.AddAttachment($"Screenshot [{DateTime.Now:HH:mm:ss}]",
                "image/png", driver.TakeScreenshot().AsByteArray);
            }
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            driver?.Close();
            driver?.Quit();
        }
    }
}
