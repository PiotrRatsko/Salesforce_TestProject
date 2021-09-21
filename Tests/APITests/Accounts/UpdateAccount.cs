using NUnit.Framework;
using Selenium_TestFrameWork.Configuration;
using System;
using System.Net;
using Tests.APITests;
using Tests.Entities;
using Tests.Support;

namespace APITests.Accounts
{
    public class UpdateAccount : BaseAPITest
    {
        string endPoint => $"{Config.ApiBaseUrl}/Account/{accountId}";

        string accountId = default;
        readonly Account requestAccount = new() { Name = Guid.NewGuid().ToString(), Description = "API Test Description", Type = "Customer - Direct" };

        [Test]
        [Category("API")]
        public void UpdateAccountTest()
        {
            requestAccount.Validate<APIAttribute>();

            //create
            accountId = APIHandler.PostRequest(endPoint, requestAccount, authToken).GetField("id");

            //update
            requestAccount.Description = "Description was updated";
            var response = APIHandler.PatchRequest(endPoint, requestAccount, authToken);
            Assert.AreEqual(HttpStatusCode.NoContent, response.StatusCode);

            //get
            response = APIHandler.GetRequest(endPoint, authToken);
            Account responseAccount = response.GetEntity<Account>();
            requestAccount.IsEqual<APIAttribute>(responseAccount);
        }

        [TearDown]
        public void DeleteAccount()
        {
            //delete
            if (accountId != default)
            {
                var response = APIHandler.DeleteRequest(endPoint, authToken);
                Assert.AreEqual(HttpStatusCode.NoContent, response.StatusCode);
            }
        }
    }
}
