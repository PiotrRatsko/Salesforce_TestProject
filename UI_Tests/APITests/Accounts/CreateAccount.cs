using API_TestFrameWork;
using FluentAssertions;
using NUnit.Framework;
using Selenium_TestFrameWork.Configuration;
using System.Net;
using Tests.APITests;
using Tests.Entities;

namespace APITests.Accounts
{
    public class CreateAccount : BaseAPITest
    {
        readonly Account expectedAccount = new() { Name = "API Test Account", Description = "API Test Description", Type = "Customer - Direct" };
        readonly string endPoint = $"{Config.ApiBaseUrl}/Account/";

        [Test]
        [Category("API")]
        public void CreateAccountTest()
        {
            //create
            expectedAccount.Validate();
            
            var response = API_Helper.PostRequest(endPoint, expectedAccount, authToken);
            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
            string accountId = response.GetField("id");

            //get
            response = API_Helper.GetRequest(endPoint + accountId, authToken);
            Account actualAccount = response.GetEntity<Account>();
            expectedAccount.Should().BeEquivalentTo(actualAccount);

            //delete
            response = API_Helper.DeleteRequest(endPoint + accountId, authToken);
            Assert.AreEqual(HttpStatusCode.NoContent, response.StatusCode);
        }
    }
}
