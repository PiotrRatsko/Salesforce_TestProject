using NUnit.Framework;
using Selenium_TestFrameWork.Configuration;
using System;
using System.Net;
using Tests.APITests;
using Tests.Entities;
using Tests.Support;
using Tests.Support.CustomAttributes;

namespace APITests.Accounts
{
    public class CreateAccount : BaseAPITest
    {
        readonly string endPoint = $"{Config.ApiBaseUrl}/Account/";
        readonly Account account = new Account()
        {
            Name = Guid.NewGuid().ToString(),
            Description = "API"
        }.Validate() as Account;

        [Test]
        [Category("API")]
        public void CreateAccountTest()
        {
            //create
            var responsePost = APIHandler.PostRequest(account, endPoint, authToken);
            Assert.AreEqual(HttpStatusCode.Created, responsePost.StatusCode);
            account.Id = responsePost.GetField("id");

            //get
            var responseGet = APIHandler.GetRequest(account.Id, endPoint, authToken);

            //assert
            var expectedAccount = account.TransformTo<GetAPI>();
            responseGet.IsContains(expectedAccount);
        }

        [TearDown]
        public void DeleteAccount()
        {
            //delete
            APIHandler.DeleteRequest(account.Id, endPoint, authToken);
        }
    }
}
