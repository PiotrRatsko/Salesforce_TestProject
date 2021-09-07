using Microsoft.Extensions.Configuration;
using System;

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
            UserName = config["UserName"];
            Password = config["Password"];
            WebSite = config["WebSite"];
            ScreenshotStorage = config["ScreenshotStorage"];
            PageLoadTimeout = int.Parse(config["PageLoadTimeout"]);
            ElementLoadTimeout = int.Parse(config["ElementLoadTimeout"]);
        }
        public static BrowserType BrowserType { get; }
        public static string UserName { get; }
        public static string Password { get; }
        public static string WebSite { get; }
        public static string ScreenshotStorage { get; }
        public static int PageLoadTimeout { get; }
        public static int ElementLoadTimeout { get; }
    }
}
