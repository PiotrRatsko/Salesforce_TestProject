using NUnit.Framework;
using Selenium_TestFrameWork.Configuration;
using System.Net;
using Tests.APITests;
using Tests.Entities;
using Tests.Support;
using Tests.Support.CustomAttributes;

namespace APITests.Contacts
{
    public class CreateContact : BaseAPITest
    {
        readonly string endPoint = $"{Config.ApiBaseUrl}/Contact/";
        readonly Contact contact = new Contact()
        {
            Phone = "1",
            LastName = "Ratsko"
        }.Validate() as Contact;

        [Test]
        [Category("API")]
        public void CreateContactTest()
        {
            //create
            var responsePost = APIHandler.PostRequest(contact, endPoint, authToken);
            Assert.AreEqual(HttpStatusCode.Created, responsePost.StatusCode);
            contact.Id = responsePost.GetField("id");

            //get
            var responseGet = APIHandler.GetRequest(contact.Id, endPoint, authToken);

            //assert
            var expectedContact = contact.TransformTo<GetAPI>();
            responseGet.IsContains(expectedContact);
        }

        [TearDown]
        public void DeleteContact()
        {
            //delete
            APIHandler.DeleteRequest(contact.Id, endPoint, authToken);
        }
    }
}
