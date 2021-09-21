﻿using NUnit.Framework;
using Selenium_TestFrameWork.Configuration;
using System;
using System.Net;
using Tests.APITests;
using Tests.Entities;
using Tests.Support;

namespace APITests.Accounts
{
    public class CreateAccount : BaseAPITest
    {
        readonly string endPoint = $"{Config.ApiBaseUrl}/Account/";

        string accountId = default;
        readonly Account requestAccount = new() { Name = Guid.NewGuid().ToString(), Description = "API Test Description", Type = "Customer - Direct" };

        [Test]
        [Category("API")]
        public void CreateAccountTest()
        {
            requestAccount.Validate<APIAttribute>();

            //create
            var response = APIHandler.PostRequest(endPoint, requestAccount, authToken);
            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
            accountId = response.GetField("id");

            //get
            response = APIHandler.GetRequest(endPoint + accountId, authToken);
            Account responseAccount = response.GetEntity<Account>();
            requestAccount.IsEqual<APIAttribute>(responseAccount);
        }

        [TearDown]
        public void DeleteAccount()
        {
            //delete
            if (accountId != default)
            {
                var response = APIHandler.DeleteRequest(endPoint + accountId, authToken);
                Assert.AreEqual(HttpStatusCode.NoContent, response.StatusCode);
            }
        }
    }
}