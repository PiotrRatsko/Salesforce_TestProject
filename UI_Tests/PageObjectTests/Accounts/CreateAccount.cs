using NUnit.Framework;
using System.Threading;
using UI_Tests.PageObject.Tests;

namespace UI_Tests.PageObjectTests.Accounts
{
    public class CreateAccount : BaseTest
    {
        [Test]
        [Retry(2)]
        public void CreateAccountTest()
        {
            Thread.Sleep(10000);
        }
    }
}
