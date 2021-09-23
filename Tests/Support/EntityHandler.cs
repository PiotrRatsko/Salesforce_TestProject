using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using Selenium_TestFrameWork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using Tests.Entities;
using Tests.Support.CustomAttributes;

namespace Tests.Support
{
    public abstract class EntityHandler<T> where T : EntityHandler<T>
    {

        public ExpandoObject TransformTo<T1>() where T1 : Attribute, IAttribute
        {
            BindingFlags flags = BindingFlags.Public | BindingFlags.Instance;
            PropertyInfo[] properties = this.GetType().GetProperties(flags);
            ExpandoObject expando = new ExpandoObject();
            foreach (PropertyInfo property in properties.Where(property => property.GetCustomAttribute<T1>() != null))
            {
                expando.TryAdd(property.Name, property.GetValue(this));
            }

            //var j =JsonConvert.DeserializeObject<JObject>(JsonConvert.SerializeObject(expandoDict));
            return expando;
        }

        public T Validate()
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(this);
            if (!Validator.TryValidateObject(this, context, results, true))
            {
                foreach (var error in results)
                {
                    LogHelper.log.Error($"Validation error of entity {this.GetType().Name}: { error.ErrorMessage}");
                    Console.WriteLine(error.ErrorMessage);
                }
                throw new Exception($"Entity {this.GetType().Name} is not valid");
            }
            return this as T;
        }

        //public void IsEqualMy(IEntity actual)
        //{
        //    var expectedProp = this.GetType().GetProperties();
        //    var actualProp = actual.GetType().GetProperties();

        //    CollectionAssert.AreEquivalent(expectedProp, actualProp);

        //    //Assert.Multiple(() =>
        //    //{
        //    //    foreach (var prop in this.GetType().GetProperties())
        //    //    {
        //    //        var expectedValue = prop.GetValue(this)?.ToString();
        //    //        var actualValue = prop.GetValue(actual)?.ToString();
        //    //        if (string.IsNullOrEmpty(expectedValue)) expectedValue = null;
        //    //        if (string.IsNullOrEmpty(actualValue)) actualValue = null;
        //    //        LogHelper.log.Info($"Expected: {prop.Name} = \"{expectedValue}\". Actual: {prop.Name} = \"{actualValue}\"");
        //    //        Assert.AreEqual(expectedValue, actualValue);
        //    //    }
        //    //});
        //}
    }
}
