using NUnit.Framework;
using Selenium_TestFrameWork.Configuration;
using System.Net;
using Tests.APITests;
using Tests.Entities;
using Tests.Support;

namespace APITests.Contacts
{
    public class CreateContact : BaseAPITest
    {
        readonly string endPoint = $"{Config.ApiBaseUrl}/Contact/";

        string contactId = default;
        readonly Contact requestContact = new Contact() { Phone = "1", LastName = "b"}
            .Validate<APIAttribute>() as Contact;

        [Test]
        [Category("API")]
        public void CreateContactTest()
        {

            //create
            var response = APIHandler.PostRequest(endPoint, requestContact, authToken);
            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
            contactId = response.GetField("id");

            requestContact.Name = requestContact.LastName;

            //get
            response = APIHandler.GetRequest(endPoint + contactId, authToken);
            Contact responseContact = response.GetEntity<Contact>();
            requestContact.IsEqual<APIAttribute>(responseContact);
        }

        [TearDown]
        public void DeleteContact()
        {
            //delete
            if (contactId != default)
            {
                var response = APIHandler.DeleteRequest(endPoint + contactId, authToken);
                Assert.AreEqual(HttpStatusCode.NoContent, response.StatusCode);
            }
        }
    }
}
