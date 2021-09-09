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
            
        }

        [Test]
        [Retry(2)]
        [Order(2)]
        public void MyTest2Wrong()
        {
            
        }
    }
}
