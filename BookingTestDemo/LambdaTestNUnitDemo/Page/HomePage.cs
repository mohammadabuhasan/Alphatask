using NUnit.Framework.Constraints;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Xml.Linq;

namespace TestBookingDemo.Page
{
    public class HomePage : BasePage
    {
        private readonly By _loggedInUsername = By.XPath("//a[@class='account']//span");
        private readonly By _InputPlace = By.CssSelector("input[name='ss']");
        private readonly By _InputDate = By.CssSelector("button[data-testid='date-display-field-start']");
        private readonly By _CalenderNav = By.CssSelector("nav[data - testid = 'datepicker-tabs']");
        private readonly By _CloseRegistration = By.CssSelector("div[aria-modal='true']>div>div button");
        private readonly By _SelectFirstLi = By.CssSelector("div[data-testid = 'autocomplete-results-options'] ul>li:first-child");
        private readonly By _datePicker = By.XPath("//nav[@data-testid='datepicker-tabs']//table//tr//td[descendant::span]");
        private readonly By _searchButton = By.CssSelector("button[type='submit']");
        private By calenderNextButton = By.XPath("(//div[@data-testid='searchbox-datepicker-calendar']//button[@type='button'])[last()]");

       


        public HomePage(IWebDriver driver) : base(driver)
        {
        }

        public string GetLoggedInUsername()
        {
            return GetElement(_loggedInUsername).Text;
        }

        public bool IsHomePageAccessible()
        {

            return _driver.Title.Contains("Booking.com");
        }

        public void NavigateToStaysSection()
        {
            // Implementation to navigate to the "Stays" section
        }

        public bool IsStaysSectionLoaded()
        {
            // Implementation to check if the "Stays" section is loaded correctly
            return true; // Placeholder value, replace with actual implementation
        }

        public void InputPlaceToVIsit(String Place)
        {
            WaitForPageToLoad();
            if (IsElementPresent(_CloseRegistration)) { Click(_CloseRegistration); }
            Click(_InputPlace);
            //       WaitUntilElementVisible(_InputPlace);
            SendKeys(_InputPlace, Place);
            //       Click(_SelectFirstLi);



        }


        public void SelectDate(String Duration)
        {
            Click(_InputDate);
            WaitUntilElementVisible(_CalenderNav);
            //       String today = DateTime.Now.ToString();
            //     Console.WriteLine(today);
            //SendKeys(_InputPlace, Place);



        }
        public void clickDate()
        {
            Click(_InputDate);
        }


        public void SelectFlexibleOption()
        {
            IWebElement flexibleRadioButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("button[aria-controls='flexible-searchboxdatepicker']")));
            flexibleRadioButton.Click();
        }

        public void selectStartAndEndDate()
        {   
            (IWebElement startDateElement, int startDateclickedIndex) = ClickElementAtIndex(_driver.FindElements(_datePicker).ToList(), 8);
            string dataDateValue = startDateElement.FindElement(By.TagName("span")).GetAttribute("data-date");
            (IWebElement endDateElement, int endDateclickedIndex) = ClickElementAtIndex(_driver.FindElements(_datePicker).ToList(), startDateclickedIndex + 10);
            clickDate();
        }


        public void clickSearch()
        {
            Click(_searchButton);
        }
       
      
        public void clickCalenderNextButton()
        {
                Click(calenderNextButton);
        }

        public void clickCalenderNextButtonNTimes(int n )
        {
            for(int i = 0; i < n; i++)
                Click(calenderNextButton);
        }
    }
}