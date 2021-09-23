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
    public class UpdateAccount : BaseAPITest
    {
        string EndPoint => $"{Config.ApiBaseUrl}/Account/";
        readonly Account account = new Account()
        {
            Name = Guid.NewGuid().ToString(),
            Description = "API Test Description",
            Type = "Customer - Direct"
        }.Validate();

        [Test]
        [Category("API")]
        public void UpdateAccountTest()
        {
            //create
            var accountToPost = account.TransformTo<PostAPI>();
            account.Id = APIHandler.PostRequest(accountToPost, EndPoint, authToken).GetField("id"); ;

            //update
            account.Description = "Description was updated";
            var accountToUpdate = account.TransformTo<PatchAPI>();
            var response = APIHandler.PatchRequest(accountToUpdate, account.Id, EndPoint, authToken);
            Assert.AreEqual(HttpStatusCode.NoContent, response.StatusCode);

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
