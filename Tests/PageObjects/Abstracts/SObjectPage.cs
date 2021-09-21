using OpenQA.Selenium;
using Selenium_TestFrameWork;
using Selenium_TestFrameWork.WebDriverExtention;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading;
using Tests.Entities;
using Tests.Support;

namespace Tests.PageObject.Abstracts
{
    public abstract class SObjectPage
    {
        private readonly IWebDriver driver;

        #region IWebElements
        //protected readonly By SaveBtn = By.XPath("//button[text()='Save']"); //button for save new entity
        //protected readonly string namePath = "//div[@class ='actionBody']//label[text()='{0}']"; //path to name of the field
        //protected readonly string fieldPath = "//*[@id='{0}']"; //path to type text
        //protected readonly string comboboxElementPath = "(//div[@id='{0}']//span[@title='{1}'])[1]"; //path to choose

        protected readonly By detailsBtn = By.XPath("//div[contains(@class, 'windowViewMode-normal oneContent active')]//li[@title='Details']");
        protected readonly string detailsFieldPath = "(//div[contains(@class,'windowViewMode-normal')]//span[text()='{0}']/../following-sibling::div//slot[@slot='outputField']//*[text() !=''])[1]";
        //protected readonly string detailsNamePath = "(//div[contains(@class,'windowViewMode-normal')]//span[text()='{0}'])"; //find field name by name
        #endregion IWebElements

        public SObjectPage(IWebDriver _driver)
        {
            LogHelper.log.Info("Initialized : " + GetType().Name);
            driver = _driver;
        }

        public T GetDetails<T>() where T : IEntity, new()
        {
            T entity = new();
            IList<IWebElement> elements;
            driver.ClickButton(detailsBtn);
            Thread.Sleep(2000);
            foreach (var piInstance in entity.GetType().GetProperties().Where(prop => prop.GetCustomAttribute<GetUIAttribute>() != null))
            {
                string propName = piInstance.GetCustomAttribute<DisplayAttribute>()?.Name;
                propName ??= piInstance.Name;
                var formatedXPath = string.Format(detailsFieldPath, propName);
                elements = driver.TryGetElements(By.XPath(formatedXPath));
                if (elements.Count != 0) piInstance.SetValue(entity, elements[0].Text);
                else piInstance.SetValue(entity, null);
            }
            LogHelper.log.Info($"Got entity {entity.GetType()} by name");
            return entity;
        }
    }
}
