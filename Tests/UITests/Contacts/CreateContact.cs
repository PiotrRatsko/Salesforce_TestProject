using NUnit.Framework;
using Selenium_TestFrameWork.Configuration;
using System;
using Tests.Entities;
using Tests.PageObject;
using Tests.Support;
using Tests.Support.CustomAttributes;

namespace Tests.UITests.Contacts
{
    public class CreateContact : BaseUITest
    {
        string accountId;

        readonly Account account = new Account()
        {
            Name = Guid.NewGuid().ToString(),
            Description = "Test Description",
            Type = "Customer - Direct"
        }.Validate() as Account;

        Contact contact => new Contact()
        {
            LastName = "Ratsko",
            FirstName = "Piotr",
            Salutation = "Mr.",
            AccountName = account.Name
        }.Validate() as Contact;

        [Test]
        [Category("UI")]
        [Retry(1)]
        public void CreateContactTest()
        {
            //create account by API and get the Account id
            accountId = APIHandler.PostRequest(account, $"{Config.ApiBaseUrl}/Account/", authToken).GetField("id");

            ContactsPage cp = new ContactsPage(driver).GetPageDirectly().AddNewSObject(contact);
            var expectedContact = contact.TransformTo<GetFieldsUI>();
            var actualContact = cp.GetSObjectPage($"{contact.FirstName} {contact.LastName}").GetDetails();

            actualContact.IsContains(expectedContact);
        }

        [TearDown]
        public void TearDownUI()
        {
            APIHandler.DeleteRequest(accountId, $"{Config.ApiBaseUrl}/Account/", authToken);
        }
    }
}
