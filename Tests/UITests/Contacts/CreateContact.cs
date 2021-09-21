using NUnit.Framework;
using Tests.Entities;
using Tests.PageObject;
using Tests.Support;
using Tests.UITests;

namespace UITests
{
    public class CreateContact : BaseUITest
    {
        readonly Contact contact = new() { LastName = "Ratsko", FirstName = "Piotr", Salutation = "Ms.", AccountName = "Test Account" };

        [Test]
        [Category("UI")]
        [Retry(1)]
        public void CreateContactTest()
        {
            contact.Validate<SetUIAttribute>();
            new AccountsPage(driver).GetPageDirectly().AddNewSObject(new Account() { Name = "Test Account" });

            ContactsPage cp = new ContactsPage(driver)
                .GetPageDirectly()
                .AddNewSObject(contact);

            Contact expectedContact = new() { Name = $"{contact.Salutation} {contact.FirstName} {contact.LastName}", AccountName = contact.AccountName };
            Contact actualContact = cp.GetSObjectPage("Piotr Ratsko").GetDetails<Contact>();

            expectedContact.IsEqual<GetUIAttribute>(actualContact);
        }
    }
}
