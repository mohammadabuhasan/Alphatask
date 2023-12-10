using TestBookingDemo.Page;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;

namespace TestBookingDemo.Test
{
    [TestFixture]
    public class BookAStayTest : BaseTest
    {
        protected HomePage homePage;
        protected SearchResultsPage searchResultsPage;
        protected StayDetailsPage stayDetailsPage;
        protected UserDetailsPage userDetailsPage;
        protected CardDetailsPage cardDetailsPage;
        protected ConfirmationPage confirmationPage;



        [SetUp]
        public void SetUpHomePage()
        {
            homePage = new HomePage(Driver);
            searchResultsPage = new SearchResultsPage(Driver);
            stayDetailsPage = new StayDetailsPage(Driver);
            userDetailsPage =   new UserDetailsPage(Driver);
            cardDetailsPage = new CardDetailsPage(Driver);
            confirmationPage = new ConfirmationPage(Driver);
        }



        [Test]
        public void searchWithTermAndDateActionWithNoPrepayment()
        {
            Random random = new Random();
            int randomNumberOfNextToBeClicked = random.Next(2, 20);

            homePage.InputPlaceToVIsit("Istanbul");
            homePage.clickDate();
            homePage.clickCalenderNextButtonNTimes(randomNumberOfNextToBeClicked);
            homePage.selectStartAndEndDate();
            homePage.clickSearch();
            searchResultsPage.applyNoPrepaymentFilter();
            searchResultsPage.clickRandomAvailabilityButton();
            stayDetailsPage.clickReserve();
            stayDetailsPage.clickConfirmReserve();
            userDetailsPage.fillUserDetails();
            userDetailsPage.clickNext();
            cardDetailsPage.fillCardDetails();
            cardDetailsPage.WaitForPageToLoad();
            cardDetailsPage.clickContinueBooking();
            cardDetailsPage.clickNext();
            confirmationPage.verifyIfConfirmationBadgeIsDisplayed();
        }

        [Test]
        public void searchWithTermAndDateActionWithNoCreditCard()
        {
            Random random = new Random();
            int randomNumberOfNextToBeClicked = random.Next(2, 20);

            homePage.InputPlaceToVIsit("Istanbul");
            homePage.clickDate();
            homePage.clickCalenderNextButtonNTimes(randomNumberOfNextToBeClicked);
            homePage.selectStartAndEndDate();
            homePage.clickSearch();
            searchResultsPage.applyBookWithoutCreditCardFilter();
            searchResultsPage.clickRandomAvailabilityButton();
            stayDetailsPage.clickReserve();
            stayDetailsPage.clickConfirmReserve();
            userDetailsPage.fillUserDetails();
            userDetailsPage.clickNext();
            cardDetailsPage.fillCardDetails();
            cardDetailsPage.WaitForPageToLoad();
            cardDetailsPage.clickContinueBooking();
            cardDetailsPage.clickNext();
            confirmationPage.verifyIfConfirmationBadgeIsDisplayed();
        }







    }
}
