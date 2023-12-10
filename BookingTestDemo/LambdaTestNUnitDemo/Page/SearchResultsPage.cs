using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBookingDemo.Page
{
    public class SearchResultsPage : BasePage
    {
        private readonly By _viewAvailabilityButton = By.CssSelector("div[data-testid='availability-cta']");
        private readonly By _noPrePaymentFilter = By.XPath("(//div[@data-testid='filters-group-label-content' and contains(text(), 'No prepayment')])[1]");
        private readonly By _bookWithoutCreditCards = By.XPath("(//div[@data-testid='filters-group-label-content' and contains(text(), 'without credit card')])[1]");

        public SearchResultsPage(IWebDriver driver) : base(driver)
        {
        }

        
        public void clickRandomViewAvailabilityButton()
        {
            WaitForPageToLoad();
            ClickRandomElementAndGetClickedElement(_driver.FindElements(_viewAvailabilityButton).ToList());
        }
        public void clickRandomAvailabilityButton()
        {
            WaitForPageToLoad();
            ClickRandomElementAndGetClickedElement(_driver.FindElements(_viewAvailabilityButton).ToList());
        }
        public void applyNoPrepaymentFilter()
        {
            Click(_noPrePaymentFilter);
            waitLoadingSpinnerToBeHidden();

        }
        public void applyBookWithoutCreditCardFilter()
        {
            Click(_bookWithoutCreditCards);
            waitLoadingSpinnerToBeHidden();

        }


    }
}
