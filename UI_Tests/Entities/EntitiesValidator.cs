using Selenium_TestFrameWork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UI_Tests.Entities
{
    static class EntitiesValidator
    {
        public static T Validate<T>(this T t)
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
            return t;
        }
    }
}