using OpenQA.Selenium;
using Selenium_TestFrameWork;
using Selenium_TestFrameWork.WebDriverExtention;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using Tests.Support;

namespace Tests.PageObject.Abstracts
{
    public abstract class NewSObjectPage
    {
        private readonly IWebDriver driver;

        #region IWebElements
        protected readonly By SaveBtn = By.XPath("//button[text()='Save']"); //button for save new sObject
        protected readonly string namePath = "//div[@class ='actionBody']//label[text()='{0}']"; //path to name of the field
        protected readonly string fieldPath = "//*[@id='{0}']"; //path to type text
        protected readonly string comboboxElementPath = "(//div[@id='{0}']//span[@title='{1}'])[1]"; //path to choose
        #endregion IWebElements

        public NewSObjectPage(IWebDriver _driver)
        {
            LogHelper.log.Info("Initialized : " + GetType().Name);
            driver = _driver;
        }

        public abstract string PageTitle { get; set; }

        public void FillAndSaveNewSObject(object entity)
        {
            driver.WaitForTitle(PageTitle);
            foreach (var piInstance in entity.GetType().GetProperties().Where(prop => prop.GetValue(entity) !=null && prop.GetCustomAttribute<SetUIAttribute>() != null))
            {
                string propName = piInstance.GetCustomAttribute<DisplayAttribute>()?.Name;
                propName ??= piInstance.Name;
                var propValue = piInstance.GetValue(entity).ToString();
                IWebElement nameFieldElement = driver.GetElement(By.XPath(string.Format(namePath, propName)));
                string id = nameFieldElement.GetAttribute("for");
                string inputField = string.Format(fieldPath, id);
                IWebElement inputFieldElement = driver.GetElement(By.XPath(inputField));
                if (inputFieldElement.GetAttribute("role") == "combobox")
                {
                    inputFieldElement.ClickButton();
                    id = inputFieldElement.GetAttribute("aria-owns");
                    By comboboxElementLocator = By.XPath(string.Format(comboboxElementPath, id, propValue));
                    driver.ClickButton(comboboxElementLocator);
                    inputFieldElement.SendKeys(Keys.Tab);
                }
                else
                {
                    driver.TypeInTextBox(By.XPath(inputField), propValue);
                    driver.GetElement(By.XPath(inputField)).SendKeys(Keys.Tab);
                }
            }
            driver.ClickButton(SaveBtn);
        }
    }
}
