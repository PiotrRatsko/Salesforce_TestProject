using API_TestFrameWork;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using Selenium_TestFrameWork.Configuration;
using System.Net;
using Tests.Entities;

namespace Tests.APITests.Accounts
{
    public class CreateAccount : BaseAPITest
    {
        readonly Account account = new() { Name = "API Test Account", Description = "API Test Description", Type = "Customer - Direct" };
        readonly string endPoint = $"{Config.ApiBaseUrl}/Account/";

        [Test]
        public void CreateAccountAPITest()
        {
            //create
            account.Validate();
            var jsonData = JsonConvert.SerializeObject(account);
            var response = API_Helper.PostRequest(endPoint, jsonData, authToken);
            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
            JObject obj = JObject.Parse(response.Content);
            string accountId = (string)obj["id"];

            //get
            response = API_Helper.GetRequest(endPoint + accountId, authToken);


            //delete
            response = API_Helper.DeleteRequest(endPoint + accountId, authToken);

        }
    }
}
