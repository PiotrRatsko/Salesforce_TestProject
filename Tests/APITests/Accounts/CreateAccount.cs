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
        string EndPoint => $"{Config.ApiBaseUrl}/Account/";
        readonly Account account = new Account()
        {
            Name = Guid.NewGuid().ToString(),
            Description = "API"
        }.Validate();

        [Test]
        [Category("API")]
        public void CreateAccountTest()
        {
            //create
            var accountToPost = account.TransformTo<PostAPI>();
            var responsePost = APIHandler.PostRequest(accountToPost, EndPoint, authToken);
            Assert.AreEqual(HttpStatusCode.Created, responsePost.StatusCode);
            account.Id = responsePost.GetField("id");

            //get
            var responseGet = APIHandler.GetRequest(account.Id, EndPoint, authToken);

            //assert
            var expectedAccount = account.TransformTo<GetAPI>();
            responseGet.IsContains(expectedAccount);
        }

        [TearDown]
        public void DeleteAccount()
        {
            //delete
            if (account.Id != default)
            {
                var response = APIHandler.DeleteRequest(account.Id, EndPoint, authToken);
                Assert.AreEqual(HttpStatusCode.NoContent, response.StatusCode);
            }
        }
    }
}
