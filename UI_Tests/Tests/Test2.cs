using NUnit.Framework;
using Selenium_TestFrameWork;
using System;
using UI_Tests.BaseClass;

namespace UI_Tests.Tests
{
    public class Test2 : BaseTest
    {
        [Test]
        [Retry(2)]
        [Order(1)]
        public void MyTest2()
        {
            Console.WriteLine(driver.GetHashCode());
            LogHelper.log.Info("Starting Test: " + TestContext.CurrentContext.Test.Name);
            LogHelper.log.Info(TestContext.CurrentContext.Test.Name);
        }

        [Test]
        [Retry(2)]
        [Order(2)]
        public void MyTest2Wrong()
        {
            Console.WriteLine(driver.GetHashCode());
            LogHelper.log.Info("Starting Test: " + TestContext.CurrentContext.Test.Name);
            LogHelper.log.Info(TestContext.CurrentContext.Test.Name);
            Assert.Fail();
        }
    }
}
