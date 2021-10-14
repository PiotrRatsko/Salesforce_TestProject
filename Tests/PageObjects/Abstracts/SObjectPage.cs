using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using Selenium_TestFrameWork;
using Selenium_TestFrameWork.WebDriverExtention;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using Tests.Entities;
using Tests.Support.CustomAttributes;

namespace Tests.PageObject.Abstracts
{
    public abstract class SObjectPage
    {
        private readonly IWebDriver driver;

        #region IWebElements
        protected readonly By detailsBtn = By.XPath("//div[contains(@class, 'windowViewMode-normal oneContent active')]//li[@title='Details']");
        protected readonly string detailsFieldPath = "(//div[contains(@class,'windowViewMode-normal')]//span[text()='{0}']/../following-sibling::div//slot[@slot='outputField']//*[text() !=''])[1]";
        #endregion IWebElements

        public SObjectPage(IWebDriver _driver)
        {
            LogHelper.log.Info("Initialized : " + GetType().Name);
            driver = _driver;
        }

        public abstract IEntity Entity { get; set; }
        public JObject GetDetails()
        {
            LogHelper.log.Info($"Start to get entity {this.Entity.GetType()} from Details page");
            JObject jObj = new();
            driver.ClickButton(detailsBtn);
            foreach (var piInstance in this.Entity.GetType().GetProperties().Where(property => property.GetCustomAttribute<GetFieldsUI>() != null))
            {
                string UIName = piInstance.GetCustomAttribute<DisplayAttribute>()?.Name;
                UIName ??= piInstance.Name;
                var formatedXPath = string.Format(detailsFieldPath, UIName);
                var elements = driver.TryGetElements(By.XPath(formatedXPath));
                if (elements.Count != 0) jObj.TryAdd(piInstance.Name, elements[0].Text);
                else jObj.TryAdd(piInstance.Name, null);
            }
            return jObj;
        }
    }
}
