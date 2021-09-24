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
        readonly string endPoint = $"{Config.ApiBaseUrl}/Account/";
        readonly Account account = new Account()
        {
            Name = Guid.NewGuid().ToString(),
            Description = "API Test Description",
            Type = "Customer - Direct"
        }.Validate() as Account;

        [Test]
        [Category("API")]
        public void UpdateAccountTest()
        {
            //create
            account.Id = APIHandler.PostRequest(account, endPoint, authToken).GetField("id"); ;

            //update
            account.Description = "Description was updated";
           
            var response = APIHandler.PatchRequest(account, account.Id, endPoint, authToken);
            Assert.AreEqual(HttpStatusCode.NoContent, response.StatusCode);

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
