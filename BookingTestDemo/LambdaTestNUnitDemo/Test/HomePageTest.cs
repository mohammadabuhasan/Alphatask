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
    public class HomePageTest : BaseTest
    {
        private HomePage homePage;

        [SetUp]
        public void SetUpHomePage()
        {
            homePage = new HomePage(Driver);

            // Navigate to the Booking.com homepage (this is now handled in the BaseTest SetUp method)
        }

        [Test]
        public void TestCase_OpenBookingHomePage()
        {
            Assert.IsTrue(homePage.IsHomePageAccessible(), "Home page is not accessible.");
        }

        [Test]
        public void TestCase_NavigateToStaysSection()
        {
            homePage.NavigateToStaysSection();
            Assert.IsTrue(homePage.IsStaysSectionLoaded(), "Stays section did not load correctly.");
        }


        [Test]
        public void TestCase_InputPlaceToVist()
        {
            
            homePage.InputPlaceToVIsit("Istanbul");
            //   homePage.SelectDate("10");

            //  Assert.IsTrue(homePage.IsStaysSectionLoaded(), "Stays section did not load correctly.");
            homePage.clickDate();
            //    homePage.SelectFlexibleOption();
            homePage.clickRadnomStartAndEndDate();
            homePage.clickSearch();
            homePage.clickRandomViewAvailabilityButton();
            homePage.clickReserve();
            homePage.clickConfirmReserve();
            homePage.fillUserDetails();
            homePage.clickNext();
            homePage.fillCardDetails();
            homePage.clickNext();


        }




        // Add other test methods for the remaining test cases
    }
}
