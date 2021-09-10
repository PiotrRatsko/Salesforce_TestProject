﻿using NUnit.Framework;
using Selenium_TestFrameWork;
using Selenium_TestFrameWork.Configuration;
using System.Threading;
using UI_Tests.PageObject;
using UI_Tests.PageObject.Tests;

namespace UI_Tests.PageObjectTests.Login
{
    public class CorrectLogIn : BaseTest
    {
        [Test]
        [Retry(2)]
        public void CorrectLogInTest()
        {
            LogHelper.log.Info("Starting Test: " + TestContext.CurrentContext.Test.Name);
            StartPage hp = new(driver);
            hp.GetLoginPage().LogIn(Config.UserName, Config.Password);
            Thread.Sleep(10000);
        }
    }
}