using API_TestFrameWork;
using NUnit.Allure.Core;
using NUnit.Framework;
using Selenium_TestFrameWork.Configuration;
using System.Collections.Generic;

namespace Tests.APITests
{
    [AllureNUnit]
    [Parallelizable(scope: ParallelScope.Fixtures)]
    public class BaseAPITest
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

        [OneTimeSetUp]
        public void GetToken()
        {
            authToken = API_Helper.GetToken(Config.LoginEndpoint, parameters);
        }
    }
}
