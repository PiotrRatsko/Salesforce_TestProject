using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using Selenium_TestFrameWork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using Tests.Entities;

namespace Tests.Support
{
    static class EntityHandler
    {
        public static IEntity Validate<T>(this IEntity t) where T : Attribute, IAttribute, ISetAttribute
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(t);
            if (!Validator.TryValidateObject(t, context, results, true))
            {
                foreach (var error in results)
                {
                    LogHelper.log.Error($"Validation error of entity {t.GetType().Name}: { error.ErrorMessage}");
                    Console.WriteLine(error.ErrorMessage);
                }
                throw new Exception($"Entity {t.GetType().Name} is not valid");
            }

            foreach (var prop in t.GetType().GetProperties())
            {
                if (prop.GetCustomAttribute<T>() == null && !string.IsNullOrEmpty(prop.GetValue(t)?.ToString()))
                {
                    LogHelper.log.Error($"Try to add not applicable prop. to the request {t} {prop.Name}");
                    throw new Exception($"Try to add not applicable prop. to the request {t} {prop.Name}");
                }
            }
            return t;
        }

        public static void IsEqual<T>(this IEntity expected, IEntity actual) where T : Attribute, IGetAttribute
        {
            Assert.Multiple(() =>
            {
                foreach (var prop in expected.GetType().GetProperties().Where(prop => prop.GetCustomAttribute<T>() != null))
                {
                    var expectedValue = prop.GetValue(expected)?.ToString();
                    var actualValue = prop.GetValue(actual)?.ToString();
                    if (string.IsNullOrEmpty(expectedValue)) expectedValue = null;
                    if (string.IsNullOrEmpty(actualValue)) actualValue = null;
                    LogHelper.log.Info($"Expected: {prop.Name} = \"{expectedValue}\". Actual: {prop.Name} = \"{actualValue}\"");
                    Assert.AreEqual(expectedValue, actualValue);
                }
            });
        }

        public static T GetEntity<T>(this IRestResponse response) where T : IEntity, new()
        {
            T entity = new();
            JObject obj = JObject.Parse(response.Content);
            foreach (var piInstance in typeof(T).GetProperties().Where(prop => prop.GetCustomAttribute<APIAttribute>() != null))
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
