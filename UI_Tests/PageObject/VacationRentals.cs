using OpenQA.Selenium;
using Selenium_TestFrameWork.WebDriverExtention;
using UI_Tests.BaseClass;

namespace UI_Tests.PageObject
{
    public class VacationRentals : BasePage
    {
        #region IWebElements
        By DestinationTextBox = By.Id("VR-destination"); // Destination Textbox

        By CheckInDateTextBox = By.Id("VR-fromDate"); // Check-in Date

        By CheckOutDateTextBox = By.Id("VR-toDate"); // Check-out Date

        By NumberOfAdultGuestsDDL = By.Id("VR-NumAdult"); // Number of Guests Dropdown List

        By SearchButton = By.Id("VR-searchButtonExt1"); // Search Button

        #endregion IWebElements

        public VacationRentals(IWebDriver _driver) : base(_driver)
        { }

        #region Actions
        public void SearchVacationRentals(string destination, string checkIn, string checkOut, int numberOfGuests)
        {
            driver.TypeInTextBox(DestinationTextBox, destination);
            driver.TypeInTextBox(CheckInDateTextBox, checkIn);
            driver.TypeInTextBox(CheckOutDateTextBox, checkOut);
            driver.SelectElementByIndex(NumberOfAdultGuestsDDL, numberOfGuests);
            driver.ClickButton(SearchButton);
        }
        #endregion Actions
    }
}
