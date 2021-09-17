using NUnit.Framework;
using FluentAssertions;
using Tests.PageObject;
using Tests.Entities;
using System.Collections.Generic;
using Newtonsoft.Json;
using API_TestFrameWork;
using System.Net;

namespace Tests.APITests.Accounts
{
    public class CreateAccount /*: BaseAPITest*/
    {
        readonly Account account = new() { AccountName = "Test Account", Description = "Test Description", Type = "Customer" };
        Dictionary<string, string> headers = new Dictionary<string, string>();
        string endPoint = "https://yourInstance.salesforce.com/services/data/v53.0/sobjects/Account/";

        [Test]
        [Retry(2)]
        public void CreateAccountAPITest()
        {
            var jsonData = JsonConvert.SerializeObject(account);
            headers.Add("content-type", "application/json");
            var result = API_Helper.PostRequest(endPoint, headers, jsonData);

            Assert.AreEqual(HttpStatusCode.Created, result.StatusCode);

        }
    }
}
