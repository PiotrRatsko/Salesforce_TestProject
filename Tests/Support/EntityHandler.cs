using Newtonsoft.Json.Linq;
using NUnit.Framework;
using Selenium_TestFrameWork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using Tests.Entities;
using Tests.Support.CustomAttributes;

namespace Tests.Support
{
    public static class EntityHandler
    {
        public static void IsContains(this JObject actual, JObject expected)
        {
            Assert.Multiple(() =>
            {
                foreach (var prop in expected.Properties())
                {
                    var expectedValue = prop.Value?.ToString();
                    var actualValue = actual.GetValue(prop.Name)?.ToString();
                    if (string.IsNullOrEmpty(expectedValue)) expectedValue = null;
                    if (string.IsNullOrEmpty(actualValue)) actualValue = null;
                    if (expectedValue != actualValue)
                    {
                        LogHelper.log.Error($"{prop.Name}: expected = \"{expectedValue}\", actual = \"{actualValue}\"");
                        Assert.AreEqual(expectedValue, actualValue, $"Error in prop. \"{prop.Name}\"");
                    }
                    else
                    {
                        LogHelper.log.Info($"{prop.Name}: expected = \"{expectedValue}\", actual = \"{actualValue}\"");
                    }
                }
            });
        }

        public static JObject TransformTo<T1>(this IEntity entity) where T1 : Attribute, IAttribute
        {
            LogHelper.log.Info($"Start to transform {entity.GetType().Name} to JObject via attribute {typeof(T1)}");
            JObject jObj = (JObject)JToken.FromObject(entity);
            foreach (var property in entity.GetType().GetProperties().Where(property => property.GetCustomAttribute<T1>() == null))
            {
                jObj.Remove(property.Name);
            }
            return jObj;
        }

        public static IEntity Validate(this IEntity entity)
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(entity);
            if (!Validator.TryValidateObject(entity, context, results, true))
            {
                foreach (var error in results)
                {
                    LogHelper.log.Error($"Validation error of entity {entity.GetType().Name}: { error.ErrorMessage}");
                    Console.WriteLine(error.ErrorMessage);
                }
                throw new Exception($"Entity {entity.GetType().Name} is not valid");
            }
            return entity;
        }
    }
}
