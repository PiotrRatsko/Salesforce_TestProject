using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Reflection;

namespace Selenium_TestFrameWork.Configuration
{
    public class Config
    {
        static Config()
        {
            IConfiguration config = new ConfigurationBuilder()
                                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                                    .AddJsonFile("appsettings.json")
                                    .AddUserSecrets<Config>()
                                    .Build();

            BrowserType = (BrowserType)Enum.Parse(typeof(BrowserType), config["BrowserType"]);
            ChromeOptions = config["ChromeOptions"];
            UserName = config["UserName"];
            Password = config["Password"];
            WebSite = config["WebSite"];
            ScreenshotStorage = config["ScreenshotStorage"];
            PageLoadTimeout = int.Parse(config["PageLoadTimeout"]);
            ElementLoadTimeout = int.Parse(config["ElementLoadTimeout"]);
        }

        public static void WriteConfig2Console()
        {
            LogHelper.log.Info("Test Configuration:");
            PropertyInfo[] propertiesInfo = typeof(Config).GetProperties();

            foreach (var item in propertiesInfo.Where(i => i.Name != "Password"))
            {
                LogHelper.log.Info(item.Name + ": " + item.GetValue(item));
            }
        }
        public static BrowserType BrowserType { get; }
        public static string ChromeOptions { get; }
        public static string UserName { get; }
        public static string Password { get; }
        public static string WebSite { get; }
        public static string ScreenshotStorage { get; }
        public static int PageLoadTimeout { get; }
        public static int ElementLoadTimeout { get; }
    }
}
