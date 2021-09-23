using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using Selenium_TestFrameWork;
using System;
using System.Collections.Generic;
using System.Dynamic;

namespace Tests.Support
{
    public static class APIHandler
    {
        private static IRestResponse CallingAPI(Method httpMethod, string endPoint, string authToken, string jsonData = "")
        {
            LogHelper.log.Info($"Start API request: {httpMethod}, endPoint={endPoint}");
            var client = new RestClient(endPoint);
            var request = new RestRequest(httpMethod);
            request.AddHeader("Authorization", "Bearer " + authToken);
            request.AddHeader("Content-Type", "application/json");

            if (httpMethod == Method.PATCH || httpMethod == Method.POST)
            {
                request.AddJsonBody(jsonData);
            }
            IRestResponse response = client.Execute(request);
            LogHelper.log.Info($"Response status code: {response.StatusCode}");
            return response;
        }

        // GET Request
        public static IRestResponse GetRequest(string id, string endPoint, string authToken)
        {
            return CallingAPI(Method.GET, endPoint + id, authToken);
        }

        //POST Request
        public static IRestResponse PostRequest(dynamic obj, string endPoint, string authToken)
        {
            var jsonData = JsonConvert.SerializeObject(obj);
            return CallingAPI(Method.POST, endPoint, authToken, jsonData);
        }

        //PUT Request
        public static IRestResponse PatchRequest(dynamic obj, string id, string endPoint, string authToken)
        {
            var jsonData = JsonConvert.SerializeObject(obj);
            return CallingAPI(Method.PATCH, endPoint + id, authToken, jsonData);
        }

        //DELETE Request
        public static IRestResponse DeleteRequest(string id, string endPoint, string authToken)
        {
            return CallingAPI(Method.DELETE, endPoint + id, authToken);
        }

        public static string GetToken(string endPoint, Dictionary<string, string> parameters)
        {
            var client = new RestClient(endPoint);
            var request = new RestRequest(Method.POST);
            foreach (var item in parameters)
            {
                request.AddParameter(item.Key, item.Value, ParameterType.QueryString);
            }

            IRestResponse response = client.Execute(request);
            LogHelper.log.Info($"Got token: {response.StatusCode}");
            return response.GetField("access_token");
        }

        public static string GetField(this IRestResponse response, string field)
        {
            try
            {
                JObject obj = JObject.Parse(response.Content);
                return (string)obj[field];
            }
            catch
            {
                LogHelper.log.Error("Field did not find: " + field);
                throw new Exception("Field did not find: " + field);
            }
        }

        public static void IsContains(this IRestResponse response, ExpandoObject expected)
        {
            Assert.Multiple(() =>
            {
                foreach (var prop in (IDictionary<String, Object>)expected)
                {
                    var expectedValue = prop.Value?.ToString();
                    var actualValue = response.GetField(prop.Key)?.ToString();
                    if (string.IsNullOrEmpty(expectedValue)) expectedValue = null;
                    if (string.IsNullOrEmpty(actualValue)) actualValue = null;
                    if (expectedValue != actualValue)
                    {
                        LogHelper.log.Error($"{prop.Key}: expected = \"{expectedValue}\", actual = \"{actualValue}\"");
                        Assert.AreEqual(expectedValue, actualValue, $"Error in prop. \"{prop.Key}\"");
                    }
                    else
                    {
                        LogHelper.log.Info($"{prop.Key}: expected = \"{expectedValue}\", actual = \"{actualValue}\"");
                    }
                }
            });
        }
    }
}
