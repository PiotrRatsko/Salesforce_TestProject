using NUnit.Framework;
using Selenium_TestFrameWork.Configuration;
using System.Net;
using Tests.APITests;
using Tests.Entities;
using Tests.Support;

namespace APITests
{
    public class CreateAccount : BaseAPITest
    {
        string accountId = default;
        readonly Account expectedAccount = new() { Name = "API Test Account", Description = "API Test Description", Type = "Customer - Direct" };
        readonly string endPoint = $"{Config.ApiBaseUrl}/Account/";

        [Test]
        [Category("API")]
        public void CreateAccountTest()
        {


            expectedAccount.Validate<APIAttribute>();

            //create
            var response = APIHandler.PostRequest(endPoint, expectedAccount, authToken);
            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
            accountId = response.GetField("id");

            //get
            response = APIHandler.GetRequest(endPoint + accountId, authToken);
            Account actualAccount = response.GetEntity<Account>();
            expectedAccount.IsEqual<APIAttribute>(actualAccount);
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
