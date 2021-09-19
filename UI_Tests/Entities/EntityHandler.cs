using Newtonsoft.Json.Linq;
using RestSharp;
using Selenium_TestFrameWork;
using System;
using Tests.Entities;

namespace API_TestFrameWork
{
    static class EntityHandler
    {
        public static T GetEntity<T>(this IRestResponse response) where T : IEntity, new()
        {
            T entity = new();
            JObject obj = JObject.Parse(response.Content);
            foreach (var piInstance in typeof(T).GetProperties())
            {
                piInstance.SetValue(entity, (string)obj[piInstance.Name]);
            }
            return entity;
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
    }
}
