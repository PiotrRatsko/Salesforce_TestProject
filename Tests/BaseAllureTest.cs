using Allure.Commons;
using NUnit.Allure.Core;
using NUnit.Framework;
using Selenium_TestFrameWork.Configuration;

namespace Tests
{
    [AllureNUnit]
    [Parallelizable(scope: ParallelScope.Fixtures)]
    public class BaseAllureTest
    {
        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            AllureLifecycle.Instance.CleanupResultDirectory();
        }

        [SetUp]
        public void GetConfiguration()
        {
            Config.WriteConfig2Console();
        }
    }
}
