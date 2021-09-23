//using NUnit.Framework;
//using Selenium_TestFrameWork.Configuration;
//using System;
//using Tests.Entities;
//using Tests.PageObject;
//using Tests.Support;
//using Tests.UITests;

//namespace UITests.Contacts
//{
//    public class CreateContact : BaseUITest
//    {
//        Account account;
//        Contact contact;
//        string accountName;
//        string accountId;

//        [SetUp]
//        public void SetUp()
//        {
//            accountName = Guid.NewGuid().ToString();
//            account = new Account() { Name = accountName, Description = "Test Description", Type = "Customer - Direct" }
//                .Validate<APIAttribute>() as Account;
//            accountId = APIHandler.PostRequest($"{Config.ApiBaseUrl}/Account/", account, authToken).GetField("id");

//            contact = new Contact() { LastName = "Ratsko", FirstName = "Piotr", Salutation = "Mr.", AccountName = accountName }
//                .Validate<SetUIAttribute>() as Contact;
//        }

//        [Test]
//        [Category("UI")]
//        [Retry(1)]
//        public void CreateContactTest()
//        {
//            ContactsPage cp = new ContactsPage(driver).GetPageDirectly().AddNewSObject(contact);
//            Contact expectedContact = new() { Name = $"{contact.Salutation} {contact.FirstName} {contact.LastName}", AccountName = accountName };
//            Contact actualContact = cp.GetSObjectPage("Piotr Ratsko").GetDetails<Contact>();

//            expectedContact.IsEqual<GetUIAttribute>(actualContact);
//        }

//        [TearDown]
//        public void TearDownUI()
//        {
//            APIHandler.DeleteRequest($"{Config.ApiBaseUrl}/Account/{accountId}", authToken);
//        }
//    }
//}
