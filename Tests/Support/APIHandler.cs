using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using Selenium_TestFrameWork;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Tests.Support
{
    public class APIHandler
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
        public static IRestResponse GetRequest(string endPoint, string authToken)
        {
            return CallingAPI(Method.GET, endPoint, authToken);
        }

        //POST Request
        public static IRestResponse PostRequest(string endPoint, object obj, string authToken)
        {
            Dictionary<string, object> dict = new();
            foreach (var prop in obj.GetType().GetProperties().Where(prop => prop.GetCustomAttribute<APIAttribute>() != null))
            {
                dict.Add(prop.Name, prop.GetValue(obj));
            }
            var jsonData = JsonConvert.SerializeObject(dict);
            return CallingAPI(Method.POST, endPoint, authToken, jsonData);
        }

        //PUT Request
        public static IRestResponse PatchRequest(string endPoint, object obj, string authToken)
        {
            Dictionary<string, object> dict = new();
            foreach (var prop in obj.GetType().GetProperties().Where(prop => prop.GetCustomAttribute<APIAttribute>() != null))
            {
                dict.Add(prop.Name, prop.GetValue(obj));
            }
            var jsonData = JsonConvert.SerializeObject(dict);
            return CallingAPI(Method.PATCH, endPoint, authToken, jsonData);
        }

        //DELETE Request
        public static IRestResponse DeleteRequest(string endPoint, string authToken)
        {
            return CallingAPI(Method.DELETE, endPoint, authToken);
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
            JObject obj = JObject.Parse(response.Content);
            return (string)obj["access_token"];
        }
    }
}
