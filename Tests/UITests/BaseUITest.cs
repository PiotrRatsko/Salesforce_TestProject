using Allure.Commons;
using NUnit.Allure.Core;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.Extensions;
using Selenium_TestFrameWork.Configuration;
using Selenium_TestFrameWork.CustomException;
using Selenium_TestFrameWork.WebDriverExtention;
using System;
using System.Collections.Generic;
using Tests.Support;

namespace Tests.UITests
{
    [AllureNUnit]
    [Parallelizable(scope: ParallelScope.Fixtures)]
    public class BaseUITest
    {
        protected string authToken;
        readonly Dictionary<string, string> parameters = new()
        {
            { "grant_type", "password" },
            { "client_id", Config.ClientId },
            { "client_secret", Config.ClientSecret },
            { "username", Config.UserName },
            { "password", Config.Password }
        };

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
        public void OneTimeSetupBaseUITest()
        {
            authToken = APIHandler.GetToken(Config.LoginEndpoint, parameters);
            driver = Config.BrowserType switch
            {
                BrowserType.Firefox => new FirefoxDriver(),
                BrowserType.Chrome => GetChromeDriver(),
                BrowserType.IExplorer => new InternetExplorerDriver(),
                _ => throw new NoSuitableDriverFound("Driver Not Found: {0}" + Config.BrowserType.ToString()),
            };
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
                AllureLifecycle.Instance.AddAttachment($"ScreenShot [{DateTime.Now:HH:mm:ss}]",
                "image/png", driver.TakeScreenshot().AsByteArray);
            }
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            driver?.Quit();
        }
    }
}
