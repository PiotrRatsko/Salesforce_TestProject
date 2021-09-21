using NUnit.Framework;
using Tests.Entities;
using Tests.PageObject;
using Tests.Support;
using Tests.UITests;

namespace UITests
{
    public class CreateAccount : BaseUITest
    {
        readonly Account expectedAccount = new() { Name = "Test Account", Description = "Test Description", Type = "Customer - Direct" };

        [Test]
        [Category("UI")]
        [Retry(1)]
        public void CreateAccountTest()
        {
            expectedAccount.Validate<SetUIAttribute>();

            AccountsPage ap = new AccountsPage(driver)
                .GetPageDirectly()
                .AddNewSObject(expectedAccount);

            Account actualAccount = ap.GetSObjectPage("Test Account").GetDetails<Account>();

            expectedAccount.IsEqual<GetUIAttribute>(actualAccount);
        }
    }
}
