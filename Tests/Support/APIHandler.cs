using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using Selenium_TestFrameWork;
using System;
using System.Collections.Generic;
using Tests.Entities;
using Tests.Support.CustomAttributes;

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
        public static IRestResponse PostRequest(IEntity obj, string endPoint, string authToken)
        {
            var objToPost = obj.TransformTo<PostAPI>();
            var jsonData = JsonConvert.SerializeObject(objToPost);
            return CallingAPI(Method.POST, endPoint, authToken, jsonData);
        }

        //PUT Request
        public static IRestResponse PatchRequest(IEntity obj, string id, string endPoint, string authToken)
        {
            var objToPatch = obj.TransformTo<PatchAPI>();
            var jsonData = JsonConvert.SerializeObject(objToPatch);
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
            JObject obj = JObject.Parse(response.Content);
            if (!obj.ContainsKey(field))
            {
                LogHelper.log.Error("Field did not find in the response: " + field);
                throw new Exception("Field did not find in the response: " + field);
            }
            return (string)obj[field];
        }

        public static void IsContains(this IRestResponse response, JObject expected)
        {
            JObject jObj = (JObject)JToken.Parse(response.Content);
            jObj.IsContains(expected);
        }
    }
}
